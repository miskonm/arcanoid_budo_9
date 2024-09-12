using UnityEngine;

namespace Arkanoid.Utility
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour
    {
        #region Properties

        public static T Instance { get; private set; }

        #endregion

        #region Unity lifecycle

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            Instance = gameObject.GetComponent<T>();
        }

        #endregion
    }
}