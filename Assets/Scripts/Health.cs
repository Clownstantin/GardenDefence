using UnityEngine;

namespace GardenDefence
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;
        [Header("VFX Settigs")]
        [SerializeField] private ParticleSystem _deathVFX;
        [SerializeField] private Transform _effectPoint;
        [SerializeField] private float _effectDuration = 1f;

        public void DealDamage(float damage)
        {
            _health -= damage;

            if (_health <= Mathf.Epsilon)
            {
                TriggerDeathVFX();

                if (gameObject.layer == 3) gameObject.SetActive(false);
                else Destroy(gameObject);
            }
        }

        private void TriggerDeathVFX()
        {
            if (!_deathVFX) return;
            var effect = Instantiate(_deathVFX, _effectPoint.position, Quaternion.identity);
            Destroy(effect.gameObject, _effectDuration);
        }
    }
}