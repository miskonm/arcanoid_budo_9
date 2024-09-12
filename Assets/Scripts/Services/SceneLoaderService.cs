using Arkanoid.Utility;
using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Public methods

        public static void LoadNextLevelTest()
        {
            // TODO: Nikita remove it
            SceneManager.LoadScene("Level2");
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}