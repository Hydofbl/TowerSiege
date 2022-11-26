using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// RUIPopup altındaki RUIPopupChild yöneten ekrana ufak bildirimleri ve hataları bamamız için kullana bileceğimiz yapılardır .
/// </summary>
public class RUIPopup : MonoBehaviour
{
    #region //----> Variable
    RUIPopup m;
    public static Dictionary<string, RUIPopupChild> popupList = new Dictionary<string, RUIPopupChild>();
    public static RUIPopupChild activePopup;
    #endregion
    #region //----> Method
    private void Awake()
    {
        m = this;
    }
    private void Start()
    {
        GetChild();
    }
    private void GetChild()
    {
        var childs = GetComponentsInChildren<RUIPopupChild>();
        popupList.Clear();
        foreach (var item in childs)
        {
            item.ShotDown();
            popupList.Add(item.Id, item);
        }
    }
    /// <summary>
    /// Popup Döndüren yapı
    /// </summary>
    /// <param name="panelId">Popup Id'si</param>
    /// <returns></returns>
    public static RUIPopupChild Get(string panelId)
    {
        if (popupList.TryGetValue(panelId,out var value))
        {
            return value;
        }
        return null;
    }
    #endregion
}
