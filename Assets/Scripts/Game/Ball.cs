using System;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Vector2 _startDirection;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _yOffsetFromPlatform = 1;

        private bool _isStarted;
        private Platform _platform;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _platform = FindObjectOfType<Platform>();

            OnCreated?.Invoke(this);

            if (GameService.Instance.IsAutoPlay)
            {
                StartFlying();
            }
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            MoveWithPlatform();

            if (Input.GetMouseButtonDown(0))
            {
                StartFlying();
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnDrawGizmos()
        {
            if (!_isStarted)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_startDirection);
                // Debug.Log($"Magnitude: '{_startDirection.magnitude}'");
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
            }
        }

        #endregion

        #region Public methods

        public void ResetBall()
        {
            _isStarted = false;
            _rb.velocity = Vector2.zero;
        }

        #endregion

        #region Private methods

        private void MoveWithPlatform()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _platform.transform.position.x;
            currentPosition.y = _platform.transform.position.y + _yOffsetFromPlatform;
            transform.position = currentPosition;
        }

        private void StartFlying()
        {
            _isStarted = true;
            _rb.velocity = _startDirection.normalized * _speed;
        }

        #endregion
    }
}