using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOutEffect : MonoBehaviour
{
    private RectTransform myRectTransform;
    public float fadeValeu;
    public float fadeTime;

    private void Start()
    {
        myRectTransform = (RectTransform)transform;
        FadeStart();
    }

    void FadeStart()
    {
        myRectTransform.LeanAlpha(fadeValeu, fadeTime).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    }

    void FadeFinished()
    {
        myRectTransform.LeanAlpha(1, fadeTime).setEase(LeanTweenType.linear).setOnComplete(FadeStart);
    }
}
