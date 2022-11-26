using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Patterns.Creational;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    public Animator blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.enabled = true;
    }

    public void StartTransition()
    {
        blackScreen.enabled = true;
        blackScreen.SetTrigger("start");
    }
    public void EndTransition()
    {
        blackScreen.enabled = true;
        blackScreen.Play("End");
    }
}