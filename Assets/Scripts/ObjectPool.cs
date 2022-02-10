using System.Collections.Generic;
using UnityEngine;

namespace GardenDefence
{
    public class ObjectPool : MonoBehaviour
    {
        [Header("ObjectPool Settings")]
        [SerializeField] private Enemy[] _enemyPrefabs;
        [SerializeField] private int _capacity = 10;

        private readonly List<Enemy> _pool = new List<Enemy>();

        protected void Init(Transform parent)
        {
            for (int i = 0; i < _capacity; i++)
            {
                int enemyIndex = Random.Range(default, _enemyPrefabs.Length);

                var newEnemy = Instantiate(_enemyPrefabs[enemyIndex], parent);
                newEnemy.gameObject.SetActive(false);

                _pool.Add(newEnemy);
            }
        }

        protected bool TryGetEnemy(out Enemy enemy) => enemy = _pool.Find(e => !e.gameObject.activeSelf);

        public void ResetPool()
        {
            foreach (var enemy in _pool)
                enemy.gameObject.SetActive(false);
        }
    }
}