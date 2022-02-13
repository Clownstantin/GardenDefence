using System;
using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DefenderButton : MonoBehaviour
    {
        [SerializeField] private Defender _defenderPrefab;

        private SpriteRenderer _renderer;

        public event Action<Defender> Clicked;

        private void Start() => _renderer = GetComponent<SpriteRenderer>();

        private void OnMouseDown() => Clicked?.Invoke(_defenderPrefab);

        private void OnMouseUp() => SetColor(Color.white);

        public void SetColor(Color color) => _renderer.color = color;
    }
}
