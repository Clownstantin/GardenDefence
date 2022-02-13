using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenDefence
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadNextLevel()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            if (currentIndex < sceneCount - 1) 
                SceneManager.LoadScene(currentIndex + 1);
        }

        #region UnityEvents
        public void LoadGameOver()
        {
            int lastLevelIndex = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(lastLevelIndex);
        }

        public void RestartLevel()
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentLevelIndex);
        }

        public void LoadFirstScene()
        {
            Time.timeScale = 1; // хз ебать
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(sceneCount - sceneCount);
        }

        public void QuitGame() => Application.Quit();
        #endregion
    }
}