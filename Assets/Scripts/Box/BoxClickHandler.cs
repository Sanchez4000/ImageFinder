using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.UI;

namespace Assets.Scripts.Box
{
    public class BoxClickHandler : MonoBehaviour
    {
        [SerializeField] private ImageBox _box;

        private bool _isActive = true;
        private GoalData _goalData = null;
        private PlayerInput _playerInput = null;

        public UnityEvent OnRightClicked;
        public UnityEvent OnWrongClicked;

        public bool IsActive => _isActive;

        private void Start()
        {
            _goalData = FindObjectOfType<GoalData>();
            _playerInput = FindObjectOfType<PlayerInput>();
        }
        private void OnMouseUpAsButton()
        {
            if (_playerInput.InputActive == false)
                return;

            if (_box.Identifier == _goalData.Value)
            {
                OnRightClicked?.Invoke();
                LevelChanger levelChanger = GameObject.FindObjectOfType<LevelChanger>();
                levelChanger.ChangeLevel(false, 0);
            }
            else
            {
                OnWrongClicked?.Invoke();
            }
        }

        public void SetActive(bool active)
        {
            _isActive = active;
        }
    }
}