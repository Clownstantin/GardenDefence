using System.Collections;
using UnityEngine;

namespace GardenDefence
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _minSpawnDelay = 1f, _maxSpawnDelay = 5f;

        private bool _isSpawning = true;

        private IEnumerator Start()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
                SpawnEnemy();
            }
        }

        private void SpawnEnemy() => Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }
}