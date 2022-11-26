using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainButtons, optionsButtons,parentButtons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetOptionsMenu()
    {
        mainButtons.SetActive(false);
        optionsButtons.SetActive(true);
    }
    public void GetMainMenu()
    {
        mainButtons.SetActive(true);
        optionsButtons.SetActive(false);
    }
    public void CloseAll()
    {
        parentButtons.SetActive(false);
    }
}
