using System.Collections;
using UnityEngine;

namespace GardenDefence
{
    [RequireComponent(typeof(AudioSource), typeof(GamePauseController))]
    public class LevelController : MonoBehaviour
    {
        [Header("GameObjects")]
        [SerializeField] private EnemySpawner[] _enemySpawners;
        [SerializeField] private LoseLiveTrigger _loseTrigger;
        [SerializeField] private LevelLoader _levelLoader;
        [Header("UI")]
        [SerializeField] private GameUIController _uIController;
        [SerializeField] private CanvasGroup _levelCompleteGroup;
        [Header("Scriptable Objects")]
        [SerializeField] private EnemyKillCounter _enemyKillCounter;

        private GamePauseController _gamePause;
        private AudioSource _audioSource;
        private int _enemiesOnLevel = 0;
        private bool _levelTimerFinished = false;

        private const float SecondsToShowWinScreen = 1f;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _gamePause = GetComponent<GamePauseController>();
            _levelCompleteGroup.Close();
        }

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        private void Subscribe()
        {
            foreach (var spawner in _enemySpawners)
                spawner.EnemySpawned += OnEnemySpawn;

            _loseTrigger.EnemyKilled += OnEnemyKilled;
            _enemyKillCounter.EnemyKilled += OnEnemyKilled;

            _uIController.LevelTimerFinished += OnLevelTimerFinished;
            _uIController.LivesExpired += OnLivesExpired;
        }

        private void Unsubscribe()
        {
            foreach (var spawner in _enemySpawners)
                spawner.EnemySpawned -= OnEnemySpawn;

            _loseTrigger.EnemyKilled -= OnEnemyKilled;
            _enemyKillCounter.EnemyKilled -= OnEnemyKilled;

            _uIController.LevelTimerFinished -= OnLevelTimerFinished;
            _uIController.LivesExpired -= OnLivesExpired;
        }

        private void OnLevelTimerFinished()
        {
            foreach (var spawner in _enemySpawners)
                spawner.StopEnemySpawn();
            _levelTimerFinished = true;
        }

        private void OnLivesExpired()
        {
            _gamePause.PauseGame();
            foreach (var spawner in _enemySpawners)
                spawner.ResetPool();
        }

        private void OnEnemySpawn() => _enemiesOnLevel++;

        private void OnEnemyKilled()
        {
            _enemiesOnLevel--;
            if (_enemiesOnLevel <= 0 && _levelTimerFinished)
                StartCoroutine(HandleWinCondition());
        }

        private IEnumerator HandleWinCondition()
        {
            var delayForScreen = new WaitForSeconds(SecondsToShowWinScreen);
            yield return delayForScreen;

            if (_enemiesOnLevel <= 0)
            {
                _levelCompleteGroup.Open();
                _audioSource.Play();

                var delayForLoad = new WaitForSeconds(_audioSource.clip.length);
                yield return delayForLoad;

                _levelLoader.LoadNextLevel();
                StopCoroutine(HandleWinCondition());
            }
        }
    }
}