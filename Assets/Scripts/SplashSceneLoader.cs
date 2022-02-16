using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(AudioSource))]
    public class SplashSceneLoader : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;

        private AudioSource _audio;
        private float _clipSeconds;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _clipSeconds = _audio.clip.length;
        }

        private void Update() => WaitSoundAndLoad();

        private void WaitSoundAndLoad()
        {
            _clipSeconds -= Time.deltaTime;
            if (_clipSeconds <= Mathf.Epsilon)
            {
                if (_levelLoader.CurrentIndex == 0)
                    _levelLoader.LoadNextLevel();
                else
                    _levelLoader.LoadStartScene();
            }
        }
    }
}