using UnityEngine;
using UnityEngine.UI;

namespace GardenDefence
{
    public class OptionsController : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _defaultButton;
        [Header("Volume")]
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] [Range(0f, 1f)] private float _defaultVolume = 0.5f;
        [Header("Difficulty")]
        [SerializeField] private Slider _difficultySlider;
        [SerializeField] [Range(0f, 2f)] private int _defaultDifficulty = 1;

        private void Awake()
        {
            _volumeSlider.value = PlayerPrefsController.GetVolume();
            _difficultySlider.value = PlayerPrefsController.GetDifficulty();
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _defaultButton.onClick.AddListener(OnDefaultButtonClick);
            _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonClick);
            _defaultButton.onClick.RemoveListener(OnDefaultButtonClick);
            _volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value) => MusicPlayer.Instance.SetVolume(value);

        private void OnBackButtonClick()
        {
            PlayerPrefsController.SetVolume(_volumeSlider.value);
            PlayerPrefsController.SetDifficulty(_difficultySlider.value);
            _levelLoader.LoadStartScene();
        }

        private void OnDefaultButtonClick()
        {
            _volumeSlider.value = _defaultVolume;
            _difficultySlider.value = _defaultDifficulty;
        }
    }
}