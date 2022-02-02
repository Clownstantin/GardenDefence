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

            if (currentIndex < sceneCount - 1) SceneManager.LoadScene(currentIndex + 1);
            else SceneManager.LoadScene(currentIndex - currentIndex);
        }

        public void QuitGame() => Application.Quit();
    }
}