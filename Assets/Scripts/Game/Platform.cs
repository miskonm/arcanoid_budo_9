using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            if (GameService.Instance.IsAutoPlay)
            {
                MoveWithBall();
            }
            else
            {
                MoveWithMouse();
            }
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Ball ball = LevelService.Instance.Ball;
            if (ball == null)
            {
                return;
            }

            SetXPosition(ball.transform.position.x);
        }

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetXPosition(worldPosition.x);
        }

        private void SetXPosition(float x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = x;
            transform.position = currentPosition;
        }

        #endregion
    }
}