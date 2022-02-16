using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenDefence
{
    public class LevelLoader : MonoBehaviour
    {
        public int CurrentIndex => SceneManager.GetActiveScene().buildIndex;

        public void LoadNextLevel()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            if (currentIndex < sceneCount - 1) 
                SceneManager.LoadScene(currentIndex + 1);
        }

        public void LoadStartScene()
        {
            Time.timeScale = 1;
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(sceneCount - sceneCount + 1);
        }

        #region UnityEvents
        public void RestartLevel()
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentLevelIndex);
        }

        public void LoadOptionsScreen()
        {
            int optionsIndex = SceneManager.sceneCountInBuildSettings - 2;
            SceneManager.LoadScene(optionsIndex);
        }

        public void LoadGameOver()
        {
            int lastLevelIndex = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(lastLevelIndex);
        }

        public void QuitGame() => Application.Quit();
        #endregion
    }
}