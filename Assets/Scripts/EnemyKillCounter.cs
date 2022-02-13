using System;
using UnityEngine;

namespace GardenDefence
{
    [CreateAssetMenu(fileName = "new KillCounter", menuName = "Enemy Kill Counters", order = 51)]
    public class EnemyKillCounter : ScriptableObject
    {
        public Action EnemyKilled;

        public void IncreaceEnemyKilled() => EnemyKilled?.Invoke();
    }
}