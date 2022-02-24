using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public event Action EnemySpawned;

        private void Awake()
        {
            InitPool(_enemies);
            _warningImage.SetParent(null);
        }

        private async void Start()
        {
            await SpawnEnemy(_tokenSource.Token).SuppressCancellationThrow();

            if (_tokenSource.IsCancellationRequested)
            {
                _tokenSource.Dispose();
                _tokenSource = null;
                print("aboba");
            }
        }

        public void StopEnemySpawn()
        {
            _tokenSource.Cancel();
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

        // Experimental
        private async UniTask SpawnEnemy(CancellationToken token)
        {
            while (_isSpawning)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay)), cancellationToken: token);

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