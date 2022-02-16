using UnityEngine;

namespace GardenDefence
{
    public class PlayerPrefsController : MonoBehaviour
    {
        private const string VolumeKey = "volume";
        private const string DifficultyKey = "difficulty";

        private const float MinVolume = 0f, MaxVolume = 1f;
        private const int MinDifficulty = 0, MaxDifficulty = 2;

        public static void SetVolume(float volume)
        {
            if (volume >= MinVolume && volume <= MaxVolume)
                PlayerPrefs.SetFloat(VolumeKey, volume);
        }

        public static float GetVolume() => PlayerPrefs.GetFloat(VolumeKey);

        public static void SetDifficulty(float difficulty)
        {
            if (difficulty >= MinDifficulty && difficulty <= MaxDifficulty)
                PlayerPrefs.SetFloat(DifficultyKey, difficulty);
        }

        public static float GetDifficulty() => PlayerPrefs.GetFloat(DifficultyKey);
    }
}