using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        [Header("VFX Settigs")]
        [SerializeField] private GameObject _deathVFX;
        [SerializeField] private Transform _effectPoint;
        [SerializeField] private float _effectDuration = 1f;

        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile))
                DealDamage(projectile);
        }

        public void SetColliderActive() => _collider.enabled = true;

        private void DealDamage(Projectile projectile)
        {
            _health -= projectile.Damage;
            projectile.OnHit();

            if (_health <= 0)
            {
                TriggerDeathVFX();
                Destroy(gameObject);
            }
        }

        private void TriggerDeathVFX()
        {
            if (!_deathVFX) return;
            var effect = Instantiate(_deathVFX, _effectPoint.position, Quaternion.identity);
            Destroy(effect, _effectDuration);
        }
    }
}