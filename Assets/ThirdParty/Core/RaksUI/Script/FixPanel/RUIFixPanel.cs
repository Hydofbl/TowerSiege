using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// FixPanel Fix panelleri Yöneten Kullanıcı Tarafından Tetkilenmesi gerekmeyen bir yapı
/// </summary>
public class RUIFixPanel : MonoBehaviour
{
    #region //----> Variable
    public static Dictionary<string, RUIFix> fixPanels;
    #endregion
    private void Start()
    {
        fixPanels = new Dictionary<string, RUIFix>();
        var panels = GetComponentsInChildren<RUIFix>();
        foreach (var item in panels)
        {
            fixPanels.Add(item.fixPanelId, item);
        }
        transform.SetAsFirstSibling();
    }
    /// <summary>
    /// Panel Fixlemeye yarayan Fonksiyondur aktif edilecek olan Panel Id varilier .
    /// </summary>
    /// <param name="activePanelId">aktif edilecek olan Panel Idsi verilir .</param>
    public static void FixOpen(string activePanelId)
    {
        foreach (var item in fixPanels)
        {
            item.Value.ShotDown(activePanelId);
        }
    }
    public static RUIFix Get(string id)
    {
        if (fixPanels.TryGetValue(id,out var fix))
        {
            return fix;
        }
        return null;
    }
}
