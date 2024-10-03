using System.Collections;
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
        private bool _isLoadingNextScene;

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
            if (_isLoadingNextScene)
            {
                Debug.LogError($"[{nameof(SceneLoaderService)} : {nameof(LoadFirstLevel)}] Try load scene " +
                               $"when '{nameof(_isLoadingNextScene)}' is true");
                return;
            }

            _currentSceneIndex = 0;
            LoadCurrentScene();
        }

        public void LoadNextLevel()
        {
            if (_isLoadingNextScene)
            {
                Debug.LogError($"[{nameof(SceneLoaderService)} : {nameof(LoadNextLevel)}] Try load scene " +
                               $"when '{nameof(_isLoadingNextScene)}' is true");
                return;
            }

            _currentSceneIndex++;
            LoadCurrentScene();
        }

        public void LoadNextLevelWithDelay(float delay)
        {
            if (_isLoadingNextScene)
            {
                Debug.LogError($"[{nameof(SceneLoaderService)} : {nameof(LoadNextLevelWithDelay)}] Try load scene " +
                               $"when '{nameof(_isLoadingNextScene)}' is true");
                return;
            }

            StartCoroutine(LoadNextLevelWithDelayInternal(delay));
        }

        public void ReloadCurrentScene()
        {
            if (_isLoadingNextScene)
            {
                Debug.LogError($"[{nameof(SceneLoaderService)} : {nameof(ReloadCurrentScene)}] Try load scene " +
                               $"when '{nameof(_isLoadingNextScene)}' is true");
                return;
            }

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

        private IEnumerator LoadNextLevelWithDelayInternal(float delay)
        {
            _isLoadingNextScene = true;
            yield return new WaitForSeconds(delay);
            _isLoadingNextScene = false;

            LoadNextLevel();
        }

        #endregion
    }
}