using UnityEngine;

namespace GardenDefence
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private int _starCost = 100;

        private CurrencyDisplay _currencyDisplay;

        public int StarCost => _starCost;

        private void Start() => _currencyDisplay = FindObjectOfType<CurrencyDisplay>();

        private void AddCurrency(int amount) => _currencyDisplay.AddCurrency(amount);
    }
}