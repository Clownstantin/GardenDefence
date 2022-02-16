using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ProjectileDisableTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Projectile projectile))
                projectile.OnHit();
        }
    }
}