using UnityEngine;

namespace GardenDefence
{
    public class Defender : MonoBehaviour
    {
        [SerializeField] private int _starCost = 100;

        public int StarCost => _starCost;
    }
}