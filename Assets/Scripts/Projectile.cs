using UnityEngine;

namespace GardenDefence
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _projectileSpeed = 1f, _damage = 10f;

        private Transform _transform;

        public float Damage => _damage;

        private void Awake() => _transform = transform;

        private void Update() => _transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);

        public void OnHit() => gameObject.SetActive(false);
    }
}