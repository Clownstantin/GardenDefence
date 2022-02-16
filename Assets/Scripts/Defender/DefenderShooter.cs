using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(Animator))]
    public class DefenderShooter : ObjectPool
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPoint;

        private Animator _animator;
        private EnemySpawner _myEnemySpawner;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            InitPool(_projectilePrefab);
            SetLaneSpawner();
        }

        private void Update() => ChangeAnimationState();

        private void OnDestroy() => ResetPool();

        private void ChangeAnimationState() => _animator.SetBool(GetAnimatorBoolParamName(), IsEnemyOnLane());

        private void SetLaneSpawner()
        {
            var _enemySpawners = FindObjectsOfType<EnemySpawner>();

            foreach (var spawner in _enemySpawners)
            {
                if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
                    _myEnemySpawner = spawner;
            }
        }

        private string GetAnimatorBoolParamName()
        {
            foreach (var parameter in _animator.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Bool)
                    return parameter.name;
            }
            return default;
        }

        private bool IsEnemyOnLane()
        {
            if (!_myEnemySpawner) return false;

            Transform[] spawnerChildren = _myEnemySpawner.GetChildrenArray();
            int childrenCount = _myEnemySpawner.GetChildrenArray().Length;

            for (int i = 0; i < childrenCount; i++)
            {
                if (spawnerChildren[i].gameObject.activeSelf)
                    return true;
            }
            return false;
        }

        #region AnimationEvent
        private void Shoot()
        {
            if (TryGetObject(out GameObject projectile))
            {
                projectile.SetActive(true);
                projectile.transform.position = _shootPoint.position;
            }
        }
        #endregion
    }
}