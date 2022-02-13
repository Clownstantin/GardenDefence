using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GardenDefence
{
    [RequireComponent(typeof(Animator))]
    public class UIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private TMP_Text _starText;
        [SerializeField] private TMP_Text _livesText;
        [SerializeField] private Slider _slider;
        [Header("Values")]
        [SerializeField] private float _totalLives = 100f;
        [SerializeField] private int _starCount = 100;
        [Tooltip("Level timer in seconds")]
        [SerializeField] private float _levelTime = 10f;

        private bool _isLevelTimerFinished = false;
        private Animator _animator;

        public event Action LevelTimerFinished;
        public event Action LivesExpired;

        private void Start()
        {
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
            _totalLives -= damage;
            UpdateLives();

            if (_totalLives <= Mathf.Epsilon) LivesExpired?.Invoke();
        }

        private void SliderUpdate()
        {
            if (_isLevelTimerFinished) return;

            _slider.value = Time.timeSinceLevelLoad / _levelTime;

            if (Time.timeSinceLevelLoad >= _levelTime)
            {
                _isLevelTimerFinished = true;
                LevelTimerFinished?.Invoke();

                StopUIAnimation();
            }
        }

        private void StopUIAnimation() => _animator.speed = 0;

        private void UpdateCurrency() => _starText.text = _starCount.ToString();

        private void UpdateLives() => _livesText.text = _totalLives.ToString();
    }
}