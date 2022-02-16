using System.Collections.Generic;
using UnityEngine;

namespace GardenDefence
{
    public abstract class ObjectPool : MonoBehaviour
    {
        [Header("ObjectPool Settings")]
        [SerializeField] private int _capacity = 10;

        private List<GameObject> _pool = new List<GameObject>();

        public void ResetPool()
        {
            foreach (var enemy in _pool)
                enemy.SetActive(false);

            _pool.Clear();
            _pool = null;
        }

        protected void InitPool(Projectile prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                var spawnedObject = Instantiate(prefab, transform);

                DeactivateObjectAndAddToPool(spawnedObject.gameObject);
            }
        }

        protected void InitPool(Enemy[] prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                int index = Random.Range(default, prefab.Length);
                var spawnedObject = Instantiate(prefab[index], transform);

                DeactivateObjectAndAddToPool(spawnedObject.gameObject);
            }
        }

        protected bool TryGetObject(out GameObject enemy) => enemy = _pool.Find(e => !e.activeSelf);

        private void DeactivateObjectAndAddToPool(GameObject spawnedObject)
        {
            spawnedObject.SetActive(false);
            _pool.Add(spawnedObject);
        }
    }
}