using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingObjects : MonoBehaviour
{
    public PreparationManager preparationManager;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        preparationManager = FindObjectOfType<PreparationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        preparationManager.AddStackValue(index);
    }
}
