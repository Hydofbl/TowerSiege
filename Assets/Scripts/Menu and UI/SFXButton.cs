using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject disabledImage;
    private  int isActive; // 1 is active 0 is inactive
    private Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
        CheckActivity();
    }
    
    public void CheckActivity()
    {
        isActive = PlayerPrefs.GetInt("sfx", 1);
        if(isActive==1)
        {
            Open();
        }
        else if(isActive==0)
        {
            Close();
        }
    }
    
    public void Open()
    {
        disabledImage.SetActive(false);
        button.interactable = true;
    }
    
    public void Close()
    {
        disabledImage.SetActive(true);
        button.interactable = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isActive==1)
        {
            isActive = 0;
            Close();
        }
        else if(isActive==0)
        {
            isActive = 1;
            Open();
        }
        PlayerPrefs.SetInt("sfx", isActive);
    }
}
