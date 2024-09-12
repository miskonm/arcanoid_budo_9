using System;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _score = 1;

        #endregion

        #region Events

        public static event Action<Block> OnCreated;
        public static event Action<Block> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void OnDestroy()
        {
            GameService.Instance.AddScore(_score);
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}