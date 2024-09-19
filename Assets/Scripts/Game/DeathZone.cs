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

            if (other.gameObject.CompareTag(Tag.Ball))
            {
                GameService.Instance.RemoveLife();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }

        #endregion
    }
}