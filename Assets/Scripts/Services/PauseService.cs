using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Variables

        private bool _isPaused;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Private methods

        private void TogglePause()
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }

        #endregion
    }
}