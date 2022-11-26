using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreparationManager : MonoBehaviour
{
    public int thisLevelCost;
    public int thisLevelTargetUnitScore;
    public int currentCost;
    public TextMeshPro costText;
    public GameObject stackStartPoint;
    public int currentIndex;
    
    public GameObject[] stackElements;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        ChangeCostText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeCostText()
    {
        costText.text = currentCost + "\n/" + "\n"+thisLevelCost;
    }
    public void AddStackValue(int index)
    {
        switch(index)
        {
            case 0:
                if(currentCost+2<=thisLevelCost)
                {
                    currentCost += 2;
                    GameObject stackGO = Instantiate(stackElements[0], stackStartPoint.transform);
                    stackGO.transform.position = Vector3.zero;
                    stackGO.transform.localPosition = offset * currentIndex;
                    stackGO.GetComponent<StackObjects>().index = currentIndex;
                    currentIndex++;
                    ChangeCostText();
                }
                break;
            case 1:
                if (currentCost + 1 <= thisLevelCost)
                {
                    currentCost += 1;
                    GameObject stackGO = Instantiate(stackElements[1], stackStartPoint.transform);
                    stackGO.transform.localPosition = offset * currentIndex;
                    stackGO.GetComponent<StackObjects>().index = currentIndex;
                    currentIndex++;
                    ChangeCostText();
                }
                break;
            case 2:
                if (currentCost + 2 <= thisLevelCost)
                {
                    currentCost += 2;
                    GameObject stackGO = Instantiate(stackElements[2], stackStartPoint.transform);
                    stackGO.transform.localPosition = offset * currentIndex;
                    stackGO.GetComponent<StackObjects>().index = currentIndex;
                    currentIndex++;
                    ChangeCostText();
                }
                break;
        }
    }
}
