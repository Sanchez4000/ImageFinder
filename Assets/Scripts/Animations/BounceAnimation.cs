using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Animations
{
    public class BounceAnimation : Animation
    {
        [SerializeField] private float _scaleDuration = 0.15f;
        [SerializeField] private float[] _scaleStates =
        {
            0.80f,
            1.30f,
            1.00f,
            1.20f,
            1.00f,
        };

        protected override IEnumerator AnimationRealize()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            int scaleStatesCount = _scaleStates.Length;
            Vector3[] scaleData = new Vector3[scaleStatesCount];

            for (int i = 0; i < scaleStatesCount; i++)
            {
                scaleData[i] = new Vector3(_scaleStates[i], _scaleStates[i], 1);
            }

            Tweener tweener = null;

            for (int i = 0; i < scaleStatesCount; i++)
            {
                if (tweener != null)
                {
                    if (!tweener.active)
                    {
                        tweener = transform.DOScale(scaleData[i], _scaleDuration);
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    tweener = transform.DOScale(scaleData[i], _scaleDuration);
                }

                yield return null;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Unlock();
        }
    }
}
