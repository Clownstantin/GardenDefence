using UnityEngine;

namespace GardenDefence
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100f;
        [Header("VFX Settigs")]
        [SerializeField] private ParticleSystem _deathVFX;
        [SerializeField] private Transform _effectPoint;
        [SerializeField] private float _effectDuration = 1f;

        private float _currentHealth;

        private void Awake() => ResetHp();

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= Mathf.Epsilon)
            {
                TriggerDeathVFX();
                DestroyOrDeactivate();
            }
        }

        public void ResetHp() => _currentHealth = _maxHealth;

        protected virtual void DestroyOrDeactivate() => Destroy(gameObject);

        private void TriggerDeathVFX()
        {
            if (!_deathVFX) return;
            var effect = Instantiate(_deathVFX, _effectPoint.position, Quaternion.identity);
            Destroy(effect.gameObject, _effectDuration);
        }
    }
}