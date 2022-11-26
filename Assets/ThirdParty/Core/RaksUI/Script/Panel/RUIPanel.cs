using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Developer Sunal Orhon
/// RUIPanel is the structure that manages and enables transactions on them.
/// </summary>
public class RUIPanel : MonoBehaviour
{
    #region //----> Variable
    public static RUIPanel instance;
    /// <summary>
    /// Oluşturulan ve Yönetilecek olan Panelleri Tutacak Olan Dictinary
    /// </summary>
    public Dictionary<string, RUIPanelChild> panelList = new Dictionary<string, RUIPanelChild>();
    /// <summary>
    /// aktif Panel Barındırıyoruz 
    /// </summary>
    public RUIPanelChild activePanel;
    [Header("Raks Game UI")]
    public string startPanel;
    bool isLoading;
    #endregion
    #region //----> Method
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GetChild();
    }
    private void GetChild()
    {
        var childs = GetComponentsInChildren<RUIPanelChild>();
        panelList.Clear();
        foreach (var item in childs)
        {
            panelList.Add(item.Id, item);
            if (!startPanel.Equals(item.Id))
                item.ShotDown();
            else
                item.Open();
        }
    }
    /// <summary>
    /// Open the panel with ID .
    /// active panel close.
    /// </summary>
    /// <param name="panelId"></param>
    /// <returns></returns>
    public static RUIPanelChild Open(string panelId)
    {
        if (instance.activePanel != null && !instance.activePanel.Id.Equals(panelId))
        {
            instance.activePanel.Close();
        }
        if (instance.panelList.TryGetValue(panelId, out var panel))
        {
            panel.Open();

            return panel;
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panelId"></param>
    /// <returns></returns>
    public static RUIPanelChild Close(string panelId)
    {
        if (instance.activePanel == null)
        {
            Debug.LogError("Active Panel Not found");
            return null;
        }
        if (instance.activePanel.Id.Equals(panelId))
        {
            instance.activePanel.Close();
            return instance.activePanel;
        }
        return null;
    }
    /// <summary>
    /// Panel return with Id 
    /// </summary>
    /// <param name="panelId">Panel Id</param>
    /// <returns></returns>
    public static RUIPanelChild Get(string panelId)
    {
        if (instance.panelList.TryGetValue(panelId, out var panel))
        {
            return panel;
        }
        return null;
    }
    #endregion
}
