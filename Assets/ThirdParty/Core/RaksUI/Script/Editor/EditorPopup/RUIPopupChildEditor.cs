using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// 
/// </summary>
/// 
[CustomEditor(typeof(RUIPopupChild))]
public class RUIPopupChildEditor : Editor
{
    RUIPopupChild m;
    RCanvas mainCanvas;
    bool isFirst;

    private void OnEnable()
    {
        m = target as RUIPopupChild;
        mainCanvas = m.transform.root.GetComponent<RCanvas>();
        isFirst = false;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (!m.Id.Equals(""))
        {
            m.Id = m.Id.ToLower();
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
