namespace GardenDefence
{
    public class Trophy : Defender
    {
        private UIController _uiController;

        public void SetCurrencyUI(UIController display) => _uiController = display;

        #region AnimationEvent
        private void AddCurrency(int amount)
        {
            if (!_uiController) return;
            _uiController.AddCurrency(amount);
        }
        #endregion
    }
}