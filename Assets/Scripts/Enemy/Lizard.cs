using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(Collider2D))]
    public class Lizard : Enemy
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            DetectProjectile(collision);

            if (collision.TryGetComponent(out Defender defender))
                SetTarget(defender);
        }
    }
}