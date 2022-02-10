using TMPro;
using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(TMP_Text))]
    public class LivesDisplay : MonoBehaviour
    {
        [SerializeField] private float _totalLives = 100;
        [SerializeField] private LevelLoader _levelLoader;

        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            UpdateHealth();
        }

        public void DecreaseLives(float damage)
        {
            _totalLives -= damage;
            UpdateHealth();

            if (_totalLives <= Mathf.Epsilon)
                _levelLoader.LoadNextLevel();
        }

        private void UpdateHealth() => _text.text = _totalLives.ToString();
    }
}