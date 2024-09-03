using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}