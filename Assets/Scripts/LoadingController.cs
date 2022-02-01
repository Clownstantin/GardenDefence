using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(AudioSource))]
    public class LoadingController : MonoBehaviour
    {
        private LevelLoader _levelLoader;
        private AudioSource _audio;
        private float _clipSeconds;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _levelLoader = FindObjectOfType<LevelLoader>();
            _clipSeconds = _audio.clip.length;
        }

        private void Update()
        {
            WaitSoundAndLoad();
        }

        private void WaitSoundAndLoad()
        {
            _clipSeconds -= Time.deltaTime;
            if (_clipSeconds <= 0) _levelLoader.LoadNextLevel();
        }
    }
}