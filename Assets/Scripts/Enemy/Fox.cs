using UnityEngine;

namespace GardenDefence
{
    public class Fox : Enemy
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            DetectProjectile(collision);

            if (collision.TryGetComponent(out Gravestone gravestone))
                TriggerJumpAnimation();
            else if (collision.TryGetComponent(out Defender defender))
                SetTarget(defender);
        }

        private void TriggerJumpAnimation() => animator.SetTrigger(GetAnimatorParamID(AnimatorControllerParameterType.Trigger));
    }
}