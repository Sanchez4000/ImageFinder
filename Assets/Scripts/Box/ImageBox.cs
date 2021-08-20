using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.Animations;
using Animation = Assets.Scripts.Animations.Animation;

namespace Assets.Scripts.Box
{
    public class ImageBox : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _imageSpriteRenderer;

        private string _identifier;

        public UnityEvent OnAnimatedShowed;

        public string Identifier => _identifier;

        public void SetData(ImageData data)
        {
            _imageSpriteRenderer.sprite = data.Sprite;
            _imageSpriteRenderer.transform.localRotation = Quaternion.Euler(0, 0, -data.Rotation);
            _identifier = data.Identifier;
            name = _identifier;
        }
        public void Show(bool animated)
        {
            gameObject.SetActive(true);

            if (animated)
            {
                OnAnimatedShowed?.Invoke();
            }
        }
    }
}