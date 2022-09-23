using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private StoreLevelData levelStorage;
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = UIManager.instance;
        _uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
    }
    public void IncreaseTotalPush()
    {
        levelStorage.levelData.totalPush++;
        levelStorage.SaveData();
        _uiManager.ChangePushedObjectCount(levelStorage.levelData.totalPush);
    }
}
