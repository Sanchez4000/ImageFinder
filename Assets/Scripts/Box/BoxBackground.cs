using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Box
{
    public class BoxBackground : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private List<Color> _backgroundColorVariants;

        private void Start()
        {
            int colorId = Random.Range(0, _backgroundColorVariants.Count);
            _spriteRenderer.color = _backgroundColorVariants[colorId];
        }
    }
}