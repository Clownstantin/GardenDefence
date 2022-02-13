using System;
using UnityEngine;

namespace GardenDefence
{
    public class LoseLiveTrigger : MonoBehaviour
    {
        [SerializeField] private UIController _uiController;
        [SerializeField] private float _liveDamage = 1;

        public event Action EnemyKilled;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.gameObject.SetActive(false);
                EnemyKilled?.Invoke();
                _uiController.DecreaseLives(_liveDamage);
            }
        }
    }
}