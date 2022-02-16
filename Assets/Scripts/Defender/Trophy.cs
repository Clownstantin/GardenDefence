namespace GardenDefence
{
    public class Trophy : Defender
    {
        private GameUIController _uiController;

        public void SetCurrencyUI(GameUIController display) => _uiController = display;

        #region AnimationEvent
        private void AddCurrency(int amount)
        {
            if (!_uiController) return;
            _uiController.AddCurrency(amount);
        }
        #endregion
    }
}