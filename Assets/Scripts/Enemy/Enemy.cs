using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(Animator), typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        private Health _myHealth;
        private Defender _currentTarget;
        private Collider2D _collider;

        protected Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            _myHealth = GetComponent<Health>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _currentTarget = null;
            _collider.enabled = false;
        }

        private void Update() => ChangeAnimationState();

        protected void DetectProjectile(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile))
            {
                _myHealth.DealDamage(projectile.Damage);
                projectile.OnHit();
            }
        }

        protected void SetTarget(Defender target) => _currentTarget = target;

        protected int GetAnimatorParamID(AnimatorControllerParameterType type)
        {
            foreach (var parameter in animator.parameters)
            {
                if (parameter.type == type)
                    return parameter.nameHash;
            }
            return default;
        }

        private void ChangeAnimationState() => animator.SetBool(GetAnimatorParamID(AnimatorControllerParameterType.Bool), _currentTarget);

        #region AnimationEvents
        private void SetColliderActive() => _collider.enabled = true;

        private void AttackCurrentTarget(float damage)
        {
            if (!_currentTarget) return;
            if (_currentTarget.TryGetComponent(out Health targetHealth))
                targetHealth.DealDamage(damage);
        }
        #endregion
    }
}