using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            MoveWithMouse();
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 currentPosition = transform.position;
            currentPosition.x = worldPosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}