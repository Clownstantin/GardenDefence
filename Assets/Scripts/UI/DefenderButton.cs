using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DefenderButton : MonoBehaviour
    {
        [SerializeField] private Defender _defenderPrefab;

        private DefenderSpawner _defenderSpawner;
        private SpriteRenderer _renderer;
        private DefenderButton[] _buttons;
        private Color _defaultColor;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _defaultColor = _renderer.color;

            _defenderSpawner = FindObjectOfType<DefenderSpawner>();
            _buttons = FindObjectsOfType<DefenderButton>();
        }

        private void OnMouseDown() => ChooseDefender();

        private void ChooseDefender()
        {
            foreach (var item in _buttons)
                item._renderer.color = _defaultColor;

            _renderer.color = Color.white;

            _defenderSpawner.SetSelectedDefender(_defenderPrefab);
        }
    }
}