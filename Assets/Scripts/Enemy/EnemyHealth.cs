using UnityEngine;

namespace GardenDefence
{
    public class EnemyHealth : Health
    {
        [Space]
        [SerializeField] private EnemyKillCounter _enemyKillCounter;

        protected override void DestroyOrDeactivate()
        {
            gameObject.SetActive(false);
            _enemyKillCounter.IncreaceEnemyKilled();
        }
    }
}