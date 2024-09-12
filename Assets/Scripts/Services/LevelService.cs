using System;
using System.Collections.Generic;
using Arkanoid.Game;
using Arkanoid.Utility;

namespace Arkanoid.Services
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Variables

        private readonly List<Block> _blocks = new();

        #endregion

        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            
            Block.OnCreated += BlockCreatedCallback;
            Block.OnDestroyed += BlockDestroyedCallback;
        }

        private void OnDestroy()
        {
            Block.OnCreated -= BlockCreatedCallback;
            Block.OnDestroyed -= BlockDestroyedCallback;
        }

        #endregion

        #region Private methods

        private void BlockCreatedCallback(Block block)
        {
            _blocks.Add(block);
        }

        private void BlockDestroyedCallback(Block block)
        {
            _blocks.Remove(block);

            if (_blocks.Count == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        #endregion
    }
}