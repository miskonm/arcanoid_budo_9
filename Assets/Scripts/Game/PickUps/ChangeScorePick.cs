using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeScorePick : PickUp
    {
        #region Variables

        [SerializeField] private int _score = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.AddScore(_score);
        }

        #endregion
    }
}