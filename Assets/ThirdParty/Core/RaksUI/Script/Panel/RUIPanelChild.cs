using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor Yazılacak .
/// </summary>
public class RUIPanelChild : RUIMaster
{
    #region //----> Variable
    [Tooltip("Geriye gidelecek olan yapının Id si")]
    public string backId;
    #endregion
    public override void Open(float closeTime = 0)
    {
        base.Open(closeTime);
        RUIPanel.instance.activePanel = this;
    }
    public override void AnimationBegin()
    {
        base.AnimationBegin();
        RUIFixPanel.FixOpen(Id);
    }
}
