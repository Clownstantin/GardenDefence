using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenDefence
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadNextLevel()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int sceneCount = SceneManager.sceneCount;

            if (currentIndex < sceneCount) SceneManager.LoadScene(currentIndex + 1);
            else SceneManager.LoadScene(currentIndex - currentIndex);
        }
    }
}