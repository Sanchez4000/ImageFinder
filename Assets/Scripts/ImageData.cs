using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable] public struct ImageData
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _identifier;
        [SerializeField] [Range(0, 360f)] private float _rotation;

        public Sprite Sprite => _sprite;
        public string Identifier => _identifier;
        public float Rotation => _rotation;
    }
}