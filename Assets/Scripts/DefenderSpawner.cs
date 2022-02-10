using UnityEngine;

namespace GardenDefence
{
    public class DefenderSpawner : MonoBehaviour
    {
        private Camera _camera;
        private Defender _defender;
        private CurrencyDisplay _currencyDisplay;

        private void Start()
        {
            _camera = Camera.main;
            _currencyDisplay = FindObjectOfType<CurrencyDisplay>();
        }

        private void OnMouseDown() => AttemptToPlaceDefender();

        public void SetSelectedDefender(Defender selectedDefender) => _defender = selectedDefender;

        private void AttemptToPlaceDefender()
        {
            if (!_defender) return;
            int defenderCost = _defender.StarCost;

            if (_currencyDisplay.HasEnoughStars(defenderCost))
            {
                Instantiate(_defender, GetSnappedPosition(), Quaternion.identity);
                _currencyDisplay.SpendCurrency(defenderCost);
            }
        }

        private Vector2 GetSnappedPosition()
        {
            Vector2 wordldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            wordldPos.x = Mathf.RoundToInt(wordldPos.x);
            wordldPos.y = Mathf.RoundToInt(wordldPos.y);
            return wordldPos;
        }
    }
}