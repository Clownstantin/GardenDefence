using UnityEngine;

namespace GardenDefence
{
    public class Gravestone : Defender
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {

            }
        }
    }
}