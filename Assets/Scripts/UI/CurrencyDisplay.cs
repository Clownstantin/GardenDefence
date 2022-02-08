using TMPro;
using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(TMP_Text))]
    public class CurrencyDisplay : MonoBehaviour
    {
        [SerializeField] private int _starCount = 100;

        private TMP_Text _starText;

        private void Start()
        {
            _starText = GetComponent<TMP_Text>();
            UpdateCurrency();
        }

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

        private void UpdateCurrency() => _starText.text = _starCount.ToString();
    }
}