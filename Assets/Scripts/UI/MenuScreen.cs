using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _startButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startButton.onClick.AddListener(StartButtonClickedCallback);
        }

        #endregion

        #region Private methods

        private void StartButtonClickedCallback()
        {
            SceneLoaderService.Instance.LoadFirstLevel();
        }

        #endregion
    }
}