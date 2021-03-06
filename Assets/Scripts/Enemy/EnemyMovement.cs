using UnityEngine;

namespace GardenDefence
{
    public class EnemyMovement : MonoBehaviour
    {
        private float _currentSpeed = 1f;
        private Transform _transform;
        
        private void Start() => _transform = transform;

        private void Update() => _transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);

        #region AnimationEvent
        private void SetMoveSpeed(float speed) => _currentSpeed = speed;
        #endregion
    }
}