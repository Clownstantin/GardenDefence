using UnityEngine;

namespace GardenDefence
{
    public class DefenderShooter : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPoint;

        private void Shoot() => Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
    }
}