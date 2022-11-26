using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObjects : MonoBehaviour
{
    public int index;
    public PreparationManager preparationManager;
    public int cost;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        preparationManager = FindObjectOfType<PreparationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignPosition()
    {
        transform.localPosition = preparationManager.offset * index;
    }
    private void OnMouseDown()
    {
        foreach(StackObjects stackObjects in FindObjectsOfType<StackObjects>())
        {
            if(stackObjects.index>index)
            {
                stackObjects.index--;
                stackObjects.AssignPosition();
            }
           
        }
        preparationManager.currentIndex--;
        preparationManager.currentCost -= cost;
        preparationManager.ChangeCostText();
    }
}
