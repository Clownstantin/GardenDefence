using UnityEngine;

namespace GardenDefence
{
    public class GamePauseController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _loseCanvasGroup;

        private Collider2D _canvasCollider;

        private void Awake()
        {
            ResumeGame();

            if (_loseCanvasGroup.TryGetComponent(out Collider2D collider2D))
            {
                _canvasCollider = collider2D;
                _canvasCollider.enabled = false;
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            _loseCanvasGroup.Open();
            _canvasCollider.enabled = true;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
            _loseCanvasGroup.Close();
        }
    }
}