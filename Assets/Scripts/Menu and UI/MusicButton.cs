using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject disabledImage;
    private  int isActive; // 1 is active 0 is inactive
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        CheckActivity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckActivity()
    {
        isActive = PlayerPrefs.GetInt("music", 1);
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
        PlayerPrefs.SetInt("music", isActive);
    }
}
