using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(Animator))]
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPoint;

        private Animator _animator;
        private EnemySpawner _myEnemySpawner;
        private Transform[] _enemySpawnerChildren;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            SetLaneSpawner();
            FindSpawnerChildren();
        }

        private void Update() => ChangeAnimationState();

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

        private void FindSpawnerChildren()
        {
            if (!_myEnemySpawner) return;

            int childCount = _myEnemySpawner.transform.childCount;
            _enemySpawnerChildren = new Transform[childCount];

            for (int i = 0; i < childCount; i++)
                _enemySpawnerChildren[i] = _myEnemySpawner.transform.GetChild(i);
        }

        private bool IsEnemyOnLane()
        {
            foreach (var enemy in _enemySpawnerChildren)
                return enemy.gameObject.activeSelf;

            return default;
        }

        private void Shoot() => Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
    }
}