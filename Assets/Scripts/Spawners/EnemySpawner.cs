using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GardenDefence
{
    public class EnemySpawner : ObjectPool
    {
        [SerializeField] private Enemy[] _enemies;

        [Header("Spawn Settings")]
        [SerializeField] private float _minSpawnDelay = 1f;
        [SerializeField] private float _maxSpawnDelay = 5f;

        private bool _isSpawning = true;

        public event Action EnemySpawned;

        private void Awake() => InitPool(_enemies);

        private IEnumerator Start()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));

                if (TryGetObject(out GameObject enemy))
                {
                    enemy.SetActive(true);
                    EnemySpawned?.Invoke();
                    enemy.transform.position = transform.position;
                }
            }
        }

        public void StopEnemySpawn()
        {
            StopCoroutine(Start());
            _isSpawning = false;
        }

        public Transform[] GetChildrenArray()
        {
            int childCount = transform.childCount;
            Transform[] childrenArray = new Transform[childCount];

            for (int i = 0; i < childCount; i++)
                childrenArray[i] = transform.GetChild(i);

            return childrenArray;
        }
    }
}