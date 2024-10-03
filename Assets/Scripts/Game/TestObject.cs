using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Arkanoid.Game
{
    public class TestObject : MonoBehaviour
    {
        #region Variables

        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private float _fadeTime = 1f;

        #endregion

        #region Private methods

        [Button]
        private void FadeIn()
        {
            StartCoroutine(FadeInInternal());
        }

        private IEnumerator FadeInInternal()
        {
            Color color = _renderer.color;
            float currentTime = _fadeTime;

            while (currentTime > 0)
            {
                float deltaTime = Time.deltaTime / _fadeTime;
                color.a += deltaTime;
                _renderer.color = color;
                yield return null;
                currentTime -= Time.deltaTime;
            }
        }

        [Button]
        private void FadeOut()
        {
            StartCoroutine(FadeOutInternal());
        }

        private IEnumerator FadeOutInternal()
        {
            Color color = _renderer.color;
            for (float alpha = 1f; alpha >= -0.1; alpha -= 0.01f)
            {
                color.a = alpha;
                _renderer.color = color;
                yield return null;
            }
        }

        private void FadeOutInternalV1()
        {
            Color color = _renderer.color;
            for (float alpha = 1f; alpha >= -0.1; alpha -= 0.01f)
            {
                color.a = alpha;
                _renderer.color = color;
            }
        }

        #endregion
    }
}