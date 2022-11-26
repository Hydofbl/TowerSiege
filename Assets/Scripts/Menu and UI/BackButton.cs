using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerDownHandler
{
    private MainMenu _mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _mainMenu.GetMainMenu();
    }
}
