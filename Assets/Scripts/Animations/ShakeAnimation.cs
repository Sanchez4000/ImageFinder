using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Animations
{
    public class ShakeAnimation : Animation
    {
        [SerializeField] private float _oneStepDuration = 0.1f;
        [SerializeField] private float[] _relativePositions = 
        { -0.02f,
           0.15f,
          -0.35f,
           0.10f,
          -0.02f,
           0
        };

        protected override IEnumerator AnimationRealize()
        {
            int movementCount = _relativePositions.Length;
            Vector3[] positions = new Vector3[movementCount];

            for (int i = 0; i < movementCount; i++)
            {
                positions[i] = new Vector3(transform.position.x + _relativePositions[i],
                                           transform.position.y,
                                           transform.position.z);
            }

            Tweener tweener = null;

            for (int i = 0; i < positions.Length; i++)
            {
                if (tweener != null)
                {
                    if (!tweener.active)
                    {
                        tweener = transform.DOMove(positions[i], _oneStepDuration);
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    tweener = transform.DOMove(positions[i], _oneStepDuration);
                }

                yield return null;
            }

            Unlock();
        }
    }
}
