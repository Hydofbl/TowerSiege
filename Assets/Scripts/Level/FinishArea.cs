using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Unit"))
        {
            scoreManager.currentScore++;
            scoreManager.UpdateTexts();
            scoreManager.DecreaseUnitCount();
            Destroy(collision.gameObject);
        }
    }
}
