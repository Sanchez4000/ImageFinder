using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.UI
{
    public class BlackScreen : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _fadeDuration;

        private void Fade(float endValue, float duration)
        {
            Color color = Color.black;
            color.a = endValue == 1 ? 0 : 1;
            _image.color = color;
            _image.DOFade(endValue, duration);
        }

        public void FadeIn()
        {
            Fade(1, _fadeDuration);
        }

        public void FadeOut()
        {
            Fade(0, _fadeDuration);
        }
    }
}