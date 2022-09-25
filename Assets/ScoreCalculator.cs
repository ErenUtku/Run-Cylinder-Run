using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private StoreLevelData levelStorage;
    [SerializeField] private ObjectSpawner objectSpawner;
    private OBJECTTYPE objectType;

    public int totalScore;

    private int levelUpScore;//per 100 score ++

    private CollectablesData multiplierData;
    private int multiplierValue=1;

    private UIManager _uiManager;
    private void Start()
    {
        _uiManager = UIManager.instance;

        _uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
        _uiManager.ChangeAttemptCount(levelStorage.levelData.attemptCount);
        _uiManager.ChangeScore(totalScore);
        _uiManager.ChangeLevelCount(levelStorage.levelData.level);
    }

    public void IncreaseTotalPush()
    {
        levelStorage.levelData.totalPush++;
        levelStorage.SaveData();
        _uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
    }

    public void IncreaseAttemptCount()
    {
        levelStorage.levelData.attemptCount++;
        levelStorage.SaveData();
        _uiManager.ChangeAttemptCount(levelStorage.levelData.attemptCount);
    }

    public void IncreaseScore(CollectablesData data)
    {
        if(multiplierData==null || data != multiplierData)
        {
            multiplierData = data;
            multiplierValue = 1;
        }
        else
        {
            multiplierValue++;
        }

        var addScore = ((levelStorage.levelData.level-1) * 10 + data.score * multiplierValue);
        totalScore += addScore;
        levelUpScore += addScore;

        if (levelUpScore >= 100)
        {      
            levelUpScore = levelUpScore - 100;
            objectType = OBJECTTYPE.ENEMY;

            levelStorage.levelData.level++;
            objectSpawner.InstantiateObject(objectType, levelStorage.levelData);
        }

        _uiManager.ChangeScore(totalScore);
        _uiManager.ChangeLevelCount(levelStorage.levelData.level);
    }

    public LevelData ReturnCurrentData()
    {
        return levelStorage.levelData;
    }
}
