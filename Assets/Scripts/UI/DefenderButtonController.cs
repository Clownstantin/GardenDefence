using UnityEngine;

namespace GardenDefence
{
    public class DefenderButtonController : MonoBehaviour
    {
        [SerializeField] private DefenderButton[] _buttons;
        [SerializeField] private DefenderSpawner _defenderSpawner;

        private void OnEnable()
        {
            foreach (var button in _buttons)
                button.Clicked += ChooseDefender;
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
                button.Clicked -= ChooseDefender;
        }

        private void ChooseDefender(Defender defender)
        {
            foreach (var button in _buttons)
            {
                if (!button.enabled) continue;
                button.SetColor(Color.gray);
            }

            _defenderSpawner.SetSelectedDefender(defender);
        }
    }
}