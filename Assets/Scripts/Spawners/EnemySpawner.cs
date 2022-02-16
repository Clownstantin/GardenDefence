using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GardenDefence
{
    public class EnemySpawner : ObjectPool
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Transform _warningImage;

        [Header("Spawn Settings")]
        [SerializeField] private float _minSpawnDelay = 1f;
        [SerializeField] private float _maxSpawnDelay = 5f;

        private bool _isSpawning = true;

        public event Action EnemySpawned;

        private void Awake()
        {
            InitPool(_enemies);
            _warningImage.SetParent(null);
        }

        private void Start() => StartCoroutine(SpawnEnemy());

        public void StopEnemySpawn()
        {
            StopCoroutine(SpawnEnemy());
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

        private IEnumerator SpawnEnemy()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));

                _warningImage.gameObject.SetActive(false);

                if (TryGetObject(out GameObject enemy))
                {
                    enemy.SetActive(true);
                    enemy.transform.position = transform.position;

                    EnemySpawned?.Invoke();
                }
            }
        }
    }
}