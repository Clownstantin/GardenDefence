namespace GardenDefence
{
    public class Trophy : Defender
    {
        private CurrencyDisplay _currencyDisplay;

        private void Start() => _currencyDisplay = FindObjectOfType<CurrencyDisplay>();

        private void AddCurrency(int amount)
        {
            if (!_currencyDisplay) return;
            _currencyDisplay.AddCurrency(amount);
        }
    }
}