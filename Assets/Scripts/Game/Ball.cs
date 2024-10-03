using System;
using Arkanoid.Services;
using Arkanoid.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _yOffsetFromPlatform = 1;

        [Header("Direction")]
        [SerializeField] private float _directionMin = -90;
        [SerializeField] private float _directionMax = 90;
        [SerializeField] private int _segments = 10;

        [Header("Audio")]
        [SerializeField] private AudioClip _hitAudioClip;

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

        private void OnCollisionEnter2D(Collision2D other)
        {
            AudioService.Instance.PlaySfx(_hitAudioClip);
        }

        private void OnDrawGizmos()
        {
            if (!_isStarted)
            {
                Gizmos.color = Color.green;
                GizmosUtils.DrawArc2D(transform.position, Vector2.up, _directionMin, _directionMax, _speed, _segments);
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

        private Vector3 GerRandomDirection()
        {
            float minAngleRad = _directionMin * Mathf.Deg2Rad;
            float maxAngleRad = _directionMax * Mathf.Deg2Rad;
            float randomAngle = Random.Range(minAngleRad, maxAngleRad);
            return new Vector2(Mathf.Sin(randomAngle), Mathf.Cos(randomAngle)).normalized;
        }

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
            _rb.velocity = GerRandomDirection() * _speed;
        }

        #endregion
    }
}