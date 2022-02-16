using UnityEngine;

namespace GardenDefence
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _projectileSpeed = 1f;
        [SerializeField] private float _damage = 10f;
        [Header("Rotation Settings")]
        [SerializeField] private float _rotationSpeed = 360f;
        [SerializeField] private int _rotationMultiplier = 2;
        [SerializeField] private Transform _bodyTransform;

        private Transform _transform;

        public float Damage => _damage;

        private void Awake() => _transform = transform;

        private void Update() => MoveAndRotate();

        public void OnHit() => gameObject.SetActive(false);

        private void MoveAndRotate()
        {
            _transform.Translate(_projectileSpeed * Time.deltaTime * Vector2.right);
            _bodyTransform.Rotate(0, 0, -_rotationSpeed * _rotationMultiplier * Time.deltaTime);
        }
    }
}