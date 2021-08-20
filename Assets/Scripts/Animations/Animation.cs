using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Animations
{
    public abstract class Animation : MonoBehaviour
    {
        private bool _isLocked = false;

        protected abstract IEnumerator AnimationRealize();
        protected void Unlock()
        {
            _isLocked = false;
        }

        public void Play()
        {
            if (_isLocked)
                return;

            _isLocked = true;
            StartCoroutine(AnimationRealize());
        }
    }
}