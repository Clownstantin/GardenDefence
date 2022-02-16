using System;
using TMPro;
using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DefenderButton : MonoBehaviour
    {
        [SerializeField] private Defender _defenderPrefab;
        [SerializeField] private TMP_Text _costText;

        private SpriteRenderer _renderer;

        public event Action<Defender> Clicked;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _costText.text = _defenderPrefab.StarCost.ToString();
        }

        private void OnMouseDown() => Clicked?.Invoke(_defenderPrefab);

        private void OnMouseUp() => SetColor(Color.white);

        public void SetColor(Color color) => _renderer.color = color;
    }
}
