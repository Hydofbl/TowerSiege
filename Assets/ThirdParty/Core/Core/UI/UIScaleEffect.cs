using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleEffect : MonoBehaviour
{
    public float scaleSpeedTime;
    public float maxScale;
    public float minScale;
    Vector3 maxVector3;
    Vector3 minVector3;
    // Start is called before the first frame update
    void Start()
    {
        maxVector3 = new Vector3(maxScale, maxScale, maxScale);
        minVector3 = new Vector3(minScale, minScale, minScale);
        ScaleMinStart();
    }
    private void ScaleMaxStart()
    {
        gameObject.LeanScale(maxVector3, scaleSpeedTime).setEase(LeanTweenType.linear).setOnComplete(ScaleMinStart);
    }
    private void ScaleMinStart()
    {
        gameObject.LeanScale(minVector3, scaleSpeedTime).setEase(LeanTweenType.linear).setOnComplete(ScaleMaxStart);
    }
}
