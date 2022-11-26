using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RUIPanelChild))]
public class RUIPanelChildEditor : Editor
{
    RUIPanelChild m;
    RCanvas mainCanvas;
    bool isFirst;

    private void OnEnable()
    {
        m = target as RUIPanelChild;
        mainCanvas = m.transform.root.GetComponent<RCanvas>();
        isFirst = false;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying || !Application.isEditor)
        {
            return;
        }
        if (mainCanvas.isEditMode && !isFirst)
        {
            isFirst = true;
            var panels = FindObjectsOfType<RUIMaster>();
            foreach (var item in panels)
            {
                if (!item.Id.Equals(m.Id))
                {
                    item.GetComponent<CanvasGroup>().alpha = 0;
                }
            }
        }
        m.GetComponent<CanvasGroup>().alpha = 1;
    }
}

