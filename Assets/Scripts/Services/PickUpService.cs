using Arkanoid.Game.PickUps;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Range(0, 100)]
        [SerializeField] private int _pickUpSpawnProbability;
        [SerializeField] private PickUp _pickUpPrefab;

        #endregion

        #region Public methods

        public void SpawnPickUp(Vector3 position)
        {
            if (_pickUpPrefab == null)
            {
                return;
            }

            int random = Random.Range(0, 101);
            if (random > _pickUpSpawnProbability)
            {
                Instantiate(_pickUpPrefab, position, Quaternion.identity);
            }
        }

        #endregion
    }
}