using System;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [SerializeField] private int _score;

        #endregion

        #region Events

        public event Action<int> OnScoreChanged;

        #endregion

        #region Properties

        public int Score => _score;

        #endregion

        #region Unity lifecycle

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

        #endregion

        #region Private methods

        private void AllBlocksDestroyedCallback()
        {
            SceneLoaderService.LoadNextLevelTest();
        }

        #endregion
    }
}