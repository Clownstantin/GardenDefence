using UnityEngine;

namespace GardenDefence
{
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPos;

        public void Shoot() => Instantiate(_projectilePrefab, _shootPos.position, Quaternion.identity);
    }
}