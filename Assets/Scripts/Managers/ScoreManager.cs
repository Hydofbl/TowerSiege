using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public int targetScore;
    [HideInInspector] public int currentScore;
    public TextMeshPro targetScoreText, currentScoreText;
    public PreparationManager preparationManager;
    [HideInInspector]public int unitCount;
    // Start is called before the first frame update
    void Start()
    {
        preparationManager = GetComponent<PreparationManager>();
        targetScore = preparationManager.thisLevelTargetUnitScore;
        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecreaseUnitCount()
    {
        unitCount--;
        if(unitCount==0)
        {
            if(currentScore>=targetScore)
            {
                Time.timeScale = 0;
                UIManager.Instance.ChangeTextValues();
                UIManager.Instance.OpenNextLevel();

            }
            else
            {
                Time.timeScale = 0;
                UIManager.Instance.ChangeTextValues();
                UIManager.Instance.OpenRestart();

            }
        }
    }
    public void UpdateTexts()
    {
        targetScoreText.text = "Target Score: " + targetScore;
        currentScoreText.text = "Current Score: " + currentScore;
    }
}
