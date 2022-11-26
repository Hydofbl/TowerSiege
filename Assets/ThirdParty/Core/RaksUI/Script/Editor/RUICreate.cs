using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 
/// Raks Game UI Sistemi
/// Sunal Orhon Tarafından Yapılmıştır .
/// 
/// </summary>
public class RUICreate : Editor
{
    [MenuItem("RaksUI/Create/Canvas", false, 1)]
    [MenuItem("GameObject/RaksUI/Create/Canvas", false, 0)]
    public static void CreateCanvas()
    {
        //----> Canvas Oluşturuldu 
        GameObject canvas = new GameObject();
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<RCanvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        GameObject eventSystem = new GameObject();
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
        eventSystem.transform.parent = canvas.transform;
        eventSystem.name = "Event System";
        var rCanvas = canvas.GetComponent<Canvas>();
        canvas.name = "Rask Canvas";
        var rCScaler = canvas.GetComponent<CanvasScaler>();
        rCScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        rCScaler.referenceResolution = new Vector2(1920, 1080);
        //----> RUI Panel Create
        GameObject ruiPanel = new GameObject();
        ruiPanel.AddComponent<RUIPanel>();
        var ruiPRect = ruiPanel.AddComponent<RectTransform>();
        ruiPRect.sizeDelta = rCanvas.pixelRect.size;
        ruiPRect.anchorMax = Vector2.one;
        ruiPRect.anchorMin = Vector2.zero;
        ruiPRect.anchoredPosition = rCanvas.GetComponent<RectTransform>().anchoredPosition;
        ruiPanel.name = "RUIPanel";
        ruiPanel.transform.SetParent(canvas.transform);
        //---->Fix Panel
        GameObject ruiFix = new GameObject();
        ruiFix.name = "RUIFixPanel";
        ruiFix.AddComponent<RUIFixPanel>();
        var ruiFRect = ruiFix.AddComponent<RectTransform>();
        ruiFRect.sizeDelta = rCanvas.pixelRect.size;
        ruiFRect.anchorMax = Vector2.one;
        ruiFRect.anchorMin = Vector2.zero;
        ruiFRect.anchoredPosition = rCanvas.GetComponent<RectTransform>().anchoredPosition;
        ruiFix.transform.SetParent(canvas.transform);
        //----> Popup
        GameObject ruiPopup = new GameObject();
        ruiPopup.AddComponent<RUIPopup>();
        var ruiPoRect = ruiPopup.AddComponent<RectTransform>();
        ruiPoRect.sizeDelta = rCanvas.pixelRect.size;
        ruiPoRect.anchorMax = Vector2.one;
        ruiPoRect.anchorMin = Vector2.zero;
        ruiPoRect.anchoredPosition = rCanvas.GetComponent<RectTransform>().anchoredPosition;
        ruiPopup.name = "RUIPopup";
        ruiPopup.transform.SetParent(canvas.transform);
        //----> Waiting
        GameObject waiting = new GameObject();
        waiting.AddComponent<RUIWaiting>();
        var waitRect = waiting.AddComponent<RectTransform>();
        waitRect.sizeDelta = rCanvas.pixelRect.size;
        waitRect.anchorMax = Vector2.one;
        waitRect.anchorMin = Vector2.zero;
        waitRect.anchoredPosition = rCanvas.GetComponent<RectTransform>().anchoredPosition;
        waiting.name = "RUIWaiting";
        waiting.transform.SetParent(canvas.transform);
    }
    [MenuItem("RaksUI/Create/RUIPanel", false, 1)]
    [MenuItem("GameObject/RaksUI/Create/RUIPanel", false, 0)]
    public static void CreatePanel()
    {
        var c = FindObjectOfType<RUIPanel>();
        if (c == null)
        {
            Debug.Log("Lütfen ilk olarak Raks Canvas Oluşturunuz !!");
            return;
        }
        GameObject ruiPanel = new GameObject("RUIPanel-Panel");
        ruiPanel.transform.SetParent(c.transform);
        ruiPanel.AddComponent<RUIPanelChild>();
        var ruiPRect = ruiPanel.AddComponent<RectTransform>();
        ruiPRect.localScale = Vector3.one;
        ruiPRect.localPosition = Vector3.zero;
    }
    [MenuItem("RaksUI/Create/RUIFixPanel",false,1)]
    [MenuItem("GameObject/RaksUI/Create/RUIFixPanel",false,0)]
    public static void CreateFixPanel()
    {
        var c = FindObjectOfType<RUIFixPanel>();
        if (c == null)
        {
            Debug.Log("Lütfen ilk olarak Raks Canvas Oluşturunuz !!");
            return;
        }
        GameObject ruiFixPanel = new GameObject("RUIFixPanel-Fix");
        ruiFixPanel.transform.SetParent(c.transform);
        ruiFixPanel.AddComponent<RUIFix>();
        var ruiRect = ruiFixPanel.AddComponent<RectTransform>();
        ruiRect.localScale = Vector3.one;
        ruiRect.localPosition = Vector3.zero;
    }
    [MenuItem("RaksUI/Create/RUIPopup", false, 1)]
    [MenuItem("GameObject/RaksUI/Create/RUIPopup", false, 0)]
    public static void CreateRUIPopup()
    {
        var c = FindObjectOfType<RUIPopup>();
        if (c == null)
        {
            Debug.Log("Lütfen ilk olarak Raks Canvas Oluşturunuz !!");
            return;
        }
        GameObject ruiFixPanel = new GameObject("RUIPopup-Popup");
        ruiFixPanel.transform.SetParent(c.transform);
        ruiFixPanel.AddComponent<RUIPopupChild>();
        var ruiRect = ruiFixPanel.AddComponent<RectTransform>();
        ruiRect.localScale = Vector3.one;
        ruiRect.localPosition = Vector3.zero;
    }

}
