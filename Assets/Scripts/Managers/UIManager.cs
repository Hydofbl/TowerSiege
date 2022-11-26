using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Patterns.Creational;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    public Animator blackScreen;
    public GameObject levelEndImage;
    public GameObject restartButton, nextLevelButton;
    public TextMeshProUGUI targetScoreText, yourScoreText;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.enabled = true;
        Time.timeScale = 1;
        scoreManager = GetComponent<ScoreManager>();
    }

    public void StartTransition()
    {
        blackScreen.enabled = true;
        blackScreen.SetTrigger("start");
    }
    public void EndTransition()
    {
        blackScreen.enabled = true;
        blackScreen.Play("End");
    }
    public void ChangeTextValues()
    {
        levelEndImage.SetActive(true);
        targetScoreText.text = "Target Score: " + scoreManager.targetScore;
        yourScoreText.text = "Your Score: " +  scoreManager.currentScore;
        
    }
    public void OpenRestart()
    {
        restartButton.SetActive(true);
    }
    public void OpenNextLevel()
    {
        nextLevelButton.SetActive(true);
    }

}