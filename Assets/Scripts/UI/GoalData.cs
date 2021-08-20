using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Assets.Scripts.UI
{
    public class GoalData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private float _fadeDuration = 1f;

        private string _value = "";

        public string Value => _value;

        public void SetGoal(string value, bool animated = false)
        {
            _value = value;
            _textField.text = $"Find {_value}";

            Color color = _textField.color;
            if (animated)
            {
                color.a = 0;
                _textField.DOFade(1, _fadeDuration);
            }
            else
            {
                color.a = 1;
            }
            _textField.color = color;
        }
    }
}