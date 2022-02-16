using UnityEngine;

namespace GardenDefence
{
    public class Jelly : Enemy
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            DetectProjectile(collision);

            if (collision.TryGetComponent(out Gravestone gravestone))
                TriggerGhostAnimation();
            else if (collision.TryGetComponent(out Defender defender))
                SetTarget(defender);
        }

        private void TriggerGhostAnimation() => animator.SetTrigger(GetAnimatorParamID(AnimatorControllerParameterType.Trigger));
    }
}