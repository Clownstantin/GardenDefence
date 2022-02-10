using System.Collections;
using UnityEngine;

namespace GardenDefence
{
    public class EnemySpawner : ObjectPool
    {
        [Header("Spawn Settings")]
        [SerializeField] private float _minSpawnDelay = 1f;
        [SerializeField] private float _maxSpawnDelay = 5f;
        [SerializeField] private bool _isSpawning = true;

        private void Awake() => Init(transform);

        private IEnumerator Start()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));

                if (TryGetEnemy(out Enemy enemy))
                {
                    enemy.gameObject.SetActive(true);
                    enemy.transform.position = transform.position;
                }
            }
        }
    }
}