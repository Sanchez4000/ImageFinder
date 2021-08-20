using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable] public class LevelData
    {
        [SerializeField] private int _horizontalSize;
        [SerializeField] private int _verticalSize;

        public int HorizontalSize => _horizontalSize;
        public int VerticalSize => _verticalSize;
        public int BoxCount => _horizontalSize * _verticalSize;
    }
}