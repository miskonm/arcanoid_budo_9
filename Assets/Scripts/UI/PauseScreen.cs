using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class PauseScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentGameObject;
        [SerializeField] private Button _continueButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _continueButton.onClick.AddListener(ContinueButtonClickedCallback);
        }

        private void Start()
        {
            PauseService.Instance.OnChanged += PauseChangedCallback;
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnChanged -= PauseChangedCallback;
        }

        #endregion

        #region Private methods

        private void ContinueButtonClickedCallback()
        {
            PauseService.Instance.TogglePause();
        }

        private void PauseChangedCallback(bool isPaused)
        {
            _contentGameObject.SetActive(isPaused);
        }

        #endregion
    }
}