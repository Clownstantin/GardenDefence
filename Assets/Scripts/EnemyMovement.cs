using UnityEngine;

namespace GardenDefence
{
    public class EnemyMovement : MonoBehaviour
    {
        [Range(0f, 5f)] [SerializeField] private float _moveSpeed = 1f;

        private Transform _transform;

        private void Awake() => _transform = transform;

        private void Update() => _transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
}