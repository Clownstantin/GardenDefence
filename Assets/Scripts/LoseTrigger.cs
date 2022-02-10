using UnityEngine;

namespace GardenDefence
{
    public class LoseTrigger : MonoBehaviour
    {
        [SerializeField] private float _liveDamage = 1;
        [SerializeField] private LivesDisplay _livesDisplay;

        private void Start() => _livesDisplay = FindObjectOfType<LivesDisplay>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.gameObject.SetActive(false);
                _livesDisplay.DecreaseLives(_liveDamage);
            }
        }
    }
}