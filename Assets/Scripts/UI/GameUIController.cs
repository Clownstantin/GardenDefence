using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GardenDefence
{
    [RequireComponent(typeof(Animator))]
    public class GameUIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private TMP_Text _starText;
        [SerializeField] private TMP_Text _livesText;
        [SerializeField] private Slider _timerSlider;
        [Header("Values")]
        [SerializeField] private float _totalLives = 100f;
        [SerializeField] private int _starCount = 100;
        [Tooltip("Level timer in seconds")]
        [SerializeField] private float _levelTime = 10f;

        private Animator _animator;
        private float _currentLives;
        private bool _isLevelTimerFinished = false;

        public event Action LevelTimerFinished;
        public event Action LivesExpired;

        private void Start()
        {
            _currentLives = _totalLives - PlayerPrefsController.GetDifficulty();

            _animator = GetComponent<Animator>();

            UpdateLives();
            UpdateCurrency();
        }

        private void Update() => SliderUpdate();

        public bool HasEnoughStars(int amount) => _starCount >= amount;

        public void AddCurrency(int amount)
        {
            _starCount += amount;
            UpdateCurrency();
        }

        public void SpendCurrency(int amount)
        {
            if (_starCount < amount) return;
            _starCount -= amount;
            UpdateCurrency();
        }

        public void DecreaseLives(float damage)
        {
            _currentLives -= damage;
            UpdateLives();

            if (_currentLives <= Mathf.Epsilon) LivesExpired?.Invoke();
        }

        private void SliderUpdate()
        {
            if (_isLevelTimerFinished) return;

            _timerSlider.value = Time.timeSinceLevelLoad / _levelTime;

            if (Time.timeSinceLevelLoad >= _levelTime)
            {
                _isLevelTimerFinished = true;
                LevelTimerFinished?.Invoke();

                StopUIAnimation();
            }
        }

        private void StopUIAnimation() => _animator.speed = 0;

        private void UpdateCurrency() => _starText.text = _starCount.ToString();

        private void UpdateLives() => _livesText.text = _currentLives.ToString();
    }
}