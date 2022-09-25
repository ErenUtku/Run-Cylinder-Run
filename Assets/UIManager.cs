using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;
public class UIManager : MonoBehaviour
{
    [Header("Gameplay UI")]
    [SerializeField] private Text levelCountTxt;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text attemptTxt;
    [SerializeField] private Text pushedObjectTxt;
    
    [Header("LevelFail UI")]
    [SerializeField] private GameObject levelFailObject;
    [SerializeField] private Button levelFailButton;
    
    [Header("Multiplier UI")]
    [SerializeField] private Text multiplierObjectTxt;
    [SerializeField] private Text multiplierCountTxt;

    [Header("HighScore UI")] [SerializeField]
    private Text highScoreTxt;
    
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        levelFailButton.onClick.AddListener(() => RestartScene());
        FailUIActivation(false);
    }

    public void ChangeLevelCount(int value)
    {
        levelCountTxt.text = ("Level" + " " + value);
    }

    public void ChangeHighScore(int value)
    {
        highScoreTxt.text = ("HighScore" + " : " + value);
    }

    public void ChangeScore(int value)
    {
        scoreTxt.text = ("Score" + " : " + value);
    }

    public void ChangeAttemptCount(int value)
    {
        attemptTxt.text = ("Attempt Count" + " : " + value);
    }
    public void ChangePushedObjectCount(int value)
    {
        pushedObjectTxt.text = ("Total Push"+" : "+value);
    }
    
    public void ChangeMultiplierCount(CollectablesData data,int value)
    {
        multiplierObjectTxt.text = (data.dataName.ToString());
        multiplierCountTxt.text = ("Multiplier" + " x" + value);
    }

    public void FailUIActivation(bool value)
    {
        levelFailObject.SetActive(value);
    }

    private void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
