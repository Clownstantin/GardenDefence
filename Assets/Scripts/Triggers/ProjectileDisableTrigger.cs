using UnityEngine;

namespace GardenDefence
{
    public class ProjectileDisableTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile))
                projectile.OnHit();
        }
    }
}