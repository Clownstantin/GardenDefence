using UnityEngine;

namespace GardenDefence
{
    public class MusicPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private static MusicPlayer _instance;

        public static MusicPlayer Instance => _instance;

        private void Awake()
        {
            Singleton();

            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = PlayerPrefsController.GetVolume();
        }

        public void SetVolume(float volume) => _audioSource.volume = volume;

        private void Singleton()
        {
            if (!_instance)
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }
    }
}