using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class DeathZone : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool _isActive = true;

        #endregion

        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isActive)
            {
                return;
            }
            
            SceneLoaderService.Instance.ReloadCurrentScene();
        }

        #endregion
    }
}