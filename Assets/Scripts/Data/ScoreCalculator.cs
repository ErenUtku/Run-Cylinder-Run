using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawn;
using UI;
namespace Data
{
    public class ScoreCalculator : MonoBehaviour
    {
        [SerializeField] private StoreLevelData levelStorage;
        [SerializeField] private ObjectSpawner objectSpawner;
        private OBJECTTYPE objectType;

        public int totalScore;

        private int levelUpScore; //per 100 score ++

        private CollectablesData multiplierData;
        private int multiplierValue = 1;

        private UIManager uiManager;

        private void Start()
        {
            uiManager = UIManager.instance;

            uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
            uiManager.ChangeAttemptCount(levelStorage.levelData.attemptCount);
            uiManager.ChangeScore(totalScore);
            uiManager.ChangeLevelCount(levelStorage.levelData.level);
            uiManager.ChangeHighScore(levelStorage.levelData.highScore);
        }

        public void IncreaseTotalPush()
        {
            levelStorage.levelData.totalPush++;
            levelStorage.SaveData();
            uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
        }

        public void IncreaseAttemptCount()
        {
            levelStorage.levelData.attemptCount++;
            levelStorage.SaveData();
            uiManager.ChangeAttemptCount(levelStorage.levelData.attemptCount);
        }

        public void IncreaseScore(CollectablesData data)
        {
            if (multiplierData == null || data != multiplierData)
            {
                multiplierData = data;
                multiplierValue = 1;
            }
            else
            {
                multiplierValue++;
            }

            var addScore = ((levelStorage.levelData.level - 1) * 10 + data.score * multiplierValue);
            totalScore += addScore;
            levelUpScore += addScore;

            if (levelUpScore >= 100)
            {
                levelUpScore = levelUpScore - 100;
                objectType = OBJECTTYPE.ENEMY;

                levelStorage.levelData.level++;
                objectSpawner.InstantiateObject(objectType, levelStorage.levelData);
            }

            levelStorage.levelData.currentScore += totalScore;
            if (totalScore >= levelStorage.levelData.highScore)
            {
                levelStorage.levelData.highScore = totalScore;
                uiManager.ChangeHighScore(totalScore);
            }

            uiManager.ChangeScore(totalScore);
            uiManager.ChangeLevelCount(levelStorage.levelData.level);
            uiManager.ChangeMultiplierCount(multiplierData, multiplierValue);

            levelStorage.SaveData();
        }

        public LevelData ReturnCurrentData()
        {
            return levelStorage.levelData;
        }
    }
}
