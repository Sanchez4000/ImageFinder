using Assets.Scripts.Box;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private ImageBox _boxPrefab;
        [SerializeField] private List<ImagesCollection> _objectVariants;

        private List<ImageBox> _lastGeneration = new List<ImageBox>();
        private string _targetValue = "";

        public bool GenerationComplete { get; set; }
        public List<ImageBox> LastGeneration => GenerationComplete ? _lastGeneration : null;
        public string TargetValue => GenerationComplete ? _targetValue : "";

        private void GenerateBox(int targetCount)
        {
            _lastGeneration = new List<ImageBox>();

            for (int i = 0; i < targetCount; i++)
            {
                ImageBox newBox = Instantiate(_boxPrefab);
                newBox.gameObject.SetActive(false);
                newBox.transform.parent = transform;
                _lastGeneration.Add(newBox);
            }
        }
        private void PushData()
        {
            int collectionDataIndex = Random.Range(0, _objectVariants.Count);
            List<ImageData> availableData = _objectVariants[collectionDataIndex].GetClone();

            for (int i = 0; i < _lastGeneration.Count; i++)
            {
                int randomDataIndex = Random.Range(0, availableData.Count);
                _lastGeneration[i].SetData(availableData[randomDataIndex]);
                availableData.RemoveAt(randomDataIndex);
            }
        }
        private void RollGoal(string excludedGoal)
        {
            do
            {
                int randomBoxIndex = Random.Range(0, _lastGeneration.Count);
                _targetValue = _lastGeneration[randomBoxIndex].Identifier;

                if (Input.GetKeyDown(KeyCode.Escape))
                    return;
            }
            while (_targetValue == excludedGoal);
        }
        private void SetPosition(int sizeX, int sizeY)
        {
            const float boxHalfSize = 0.5f;
            int boxIndex = 0;

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    float xPosition = -sizeX / 2f + x + boxHalfSize;
                    float yPosition = sizeY / 2f - y - boxHalfSize;

                    Vector3 boxPosition = new Vector3(xPosition, yPosition, 0);
                    _lastGeneration[boxIndex].transform.position = boxPosition;
                    boxIndex++;
                }
            }
        }
        private IEnumerator NewGeneration(LevelData levelData, string excludedGoal)
        {
            GenerationComplete = false;
            GenerateBox(levelData.BoxCount);
            yield return null;

            PushData();
            yield return null;

            RollGoal(excludedGoal);
            yield return null;

            SetPosition(levelData.HorizontalSize, levelData.VerticalSize);
            GenerationComplete = true;
        }

        public void GenerateLevel(LevelData levelData, string excludedGoal)
        {
            StartCoroutine(NewGeneration(levelData, excludedGoal));
        }
    }
}