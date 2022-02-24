using UnityEngine;

namespace GardenDefence
{
    public class DefenderSpawner : MonoBehaviour
    {
        [SerializeField] private GameUIController _uiController;
        [SerializeField] private Transform _parentForDefender;

        private Camera _camera;
        private Defender _defender;

        private void Start() => _camera = Camera.main;

        private void OnMouseDown() => AttemptToPlaceDefender();

        public void SetSelectedDefender(Defender selectedDefender) => _defender = selectedDefender;

        private void AttemptToPlaceDefender()
        {
            if (!_defender) return;
            int defenderCost = _defender.StarCost;

            if (_uiController.HasEnoughStars(defenderCost))
            {
                var defender = Instantiate(_defender, GetSnappedPosition(), Quaternion.identity);
                defender.transform.SetParent(_parentForDefender);

                if (defender.TryGetComponent(out Trophy trophy))
                    trophy.SetCurrencyUI(_uiController);

                _uiController.SpendCurrency(defenderCost);
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