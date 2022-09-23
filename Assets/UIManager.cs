using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public void FailUIActivation(bool value)
    {
        levelFailObject.SetActive(value);
    }

    private void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
