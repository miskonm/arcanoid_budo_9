using Arkanoid.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoaderService : SingletonMonoBehaviour<SceneLoaderService>
    {
        #region Variables

        [SerializeField] private string[] _levelSceneNames;

        private int _currentSceneIndex;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            DetectCurrentSceneIndex();
        }

        #endregion

        #region Public methods

        public bool HasNextLevel()
        {
            return _levelSceneNames.Length > _currentSceneIndex + 1;
        }

        public void LoadFirstLevel()
        {
            _currentSceneIndex = 0;
            LoadCurrentScene();
        }

        public void LoadNextLevel()
        {
            _currentSceneIndex++;
            LoadCurrentScene();
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion

        #region Private methods

        private void DetectCurrentSceneIndex()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            _currentSceneIndex = -1;

            for (int i = 0; i < _levelSceneNames.Length; i++)
            {
                if (string.Equals(currentSceneName, _levelSceneNames[i]))
                {
                    _currentSceneIndex = i;
                    return;
                }
            }
        }

        private void LoadCurrentScene()
        {
            SceneManager.LoadScene(_levelSceneNames[_currentSceneIndex]);
        }

        #endregion
    }
}