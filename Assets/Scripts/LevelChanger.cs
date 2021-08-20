using Assets.Scripts.Box;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class LevelChanger : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levels;
        [SerializeField] private GoalData _goalData;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private float _levelChangeTime = 1.5f;
        [SerializeField] private float _endGameDelay = 2f;

        private int _currentLevel = -1;
        private List<ImageBox> _boxes = new List<ImageBox>();

        public UnityEvent OnGameStarted;
        public UnityEvent OnGameEnded;

        private void Start()
        {
            ChangeLevel(true, 0.3f);
            OnGameStarted?.Invoke();
        }

        private IEnumerator CreateNewLevel(bool animatedShow, float showDelay, float replaceDelay)
        {
            _levelGenerator.GenerateLevel(_levels[_currentLevel], _goalData.Value);
            while (_levelGenerator.GenerationComplete == false)
            {
                yield return null;
            }

            List<ImageBox> newBoxes = _levelGenerator.LastGeneration;
            string newTarget = _levelGenerator.TargetValue;

            float delayTimer = replaceDelay;
            while (delayTimer > 0)
            {
                yield return null;
                delayTimer -= Time.deltaTime;
            }

            foreach (ImageBox item in _boxes)
            {
                Destroy(item.gameObject);
            }

            _goalData.SetGoal(newTarget, animatedShow);
            _boxes = newBoxes;
            delayTimer = 0;
            int boxIndex = 0;

            do
            {
                if (delayTimer <= 0)
                {
                    _boxes[boxIndex].Show(animatedShow);
                    boxIndex++;
                    delayTimer = showDelay;
                }
                else
                {
                    delayTimer -= Time.deltaTime;
                    yield return null;
                }
            }
            while (boxIndex < _boxes.Count);

            _playerInput.InputActive = true;
        }
        private IEnumerator EndGame()
        {
            float timer = _endGameDelay;
            while (timer > 0)
            {
                yield return null;
                timer -= Time.deltaTime;
            }

            OnGameEnded?.Invoke();
        }

        public void ChangeLevel(bool animatedShow, float showDelay)
        {
            _currentLevel++;
            _playerInput.InputActive = false;
            if (_currentLevel >= _levels.Count)
            {
                StartCoroutine(EndGame());
            }
            else
            {
                StartCoroutine(CreateNewLevel(animatedShow, showDelay, _levelChangeTime));
            }
        }
    }
}