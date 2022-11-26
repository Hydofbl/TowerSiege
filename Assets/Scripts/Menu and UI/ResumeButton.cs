using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject pauseMenu;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
