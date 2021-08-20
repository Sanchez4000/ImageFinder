using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "NewImagesCollection", menuName = "Game Data/Images Collection")]
    public class ImagesCollection : ScriptableObject, IEnumerable
    {
        [SerializeField] private List<ImageData> _images;

        public int Size => _images.Count;

        public List<ImageData> GetClone()
        {
            List<ImageData> clone = new List<ImageData>();
            foreach (ImageData item in _images)
            {
                clone.Add(item);
            }

            return clone;
        }
        public ImageData GetData(int index)
        {
            if (index < 0 || index >= _images.Count)
                throw new System.ArgumentOutOfRangeException();

            return _images[index];
        }
        public IEnumerator GetEnumerator()
        {
            return _images.GetEnumerator();
        }
    }
}