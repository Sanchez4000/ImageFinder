using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        public bool InputActive { get; set; }

        private void Start()
        {
            InputActive = false;
        }
    }
}