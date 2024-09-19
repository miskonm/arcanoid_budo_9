using System;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Auto Play")]
        [SerializeField] private bool _isAutoPlay;

        [Header("Settings")]
        [SerializeField] private int _maxLives = 3;

        [Header("Stats")]
        [SerializeField] private int _score;
        [SerializeField] private int _lives;

        #endregion

        #region Events

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public bool IsAutoPlay => _isAutoPlay;
        public int Score => _score;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();

            _lives = _maxLives;
        }

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += AllBlocksDestroyedCallback;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= AllBlocksDestroyedCallback;
        }

        #endregion

        #region Public methods

        public void AddScore(int value)
        {
            _score += value;
            OnScoreChanged?.Invoke(_score);
        }

        public void RemoveLife()
        {
            if (_lives > 0)
            {
                _lives--;

                LevelService.Instance.Ball.ResetBall();
                return;
            }

            Debug.LogError($"GAME OVER!");
        }

        #endregion

        #region Private methods

        private void AllBlocksDestroyedCallback()
        {
            if (SceneLoaderService.Instance.HasNextLevel())
            {
                SceneLoaderService.Instance.LoadNextLevel();
            }
            else
            {
                Debug.LogError($"GAME WIN!");
            }
        }

        #endregion
    }
}