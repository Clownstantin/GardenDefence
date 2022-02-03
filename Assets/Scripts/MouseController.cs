using UnityEngine;

namespace GardenDefence
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private Defender _defenderPrefab;

        private Camera _camera;

        private void Awake() => _camera = Camera.main;

        private void OnMouseDown() => SpawnDefender();

        private void SpawnDefender()
        {
            if (!_defenderPrefab) return;
            Instantiate(_defenderPrefab, GetSnappedPosition(), Quaternion.identity);
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