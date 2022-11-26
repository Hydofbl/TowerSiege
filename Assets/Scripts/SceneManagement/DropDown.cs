using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class DropDown : MonoBehaviour
{
    [HideInInspector]
    public int sceneIdx = 0;
    [HideInInspector]
    public string[] scenes;
    public float transitionTime;
    void Awake()
    {
        var sceneNumber = SceneManager.sceneCountInBuildSettings;
        scenes = new string[sceneNumber];
        for (int i = 0; i < sceneNumber; i++)
        {
            scenes[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
    }
    public IEnumerator GetNextScene()
    {
        UIManager.Instance.StartTransition();
        yield return new WaitForSeconds(transitionTime);
        sceneIdx = PlayerPrefs.GetInt("Level", 0);
        sceneIdx++;
        sceneIdx %= scenes.Length;
        if(sceneIdx==0)
        {
            sceneIdx++;
        }
        PlayerPrefs.SetInt("Level", sceneIdx);
        SceneManager.LoadScene(scenes[sceneIdx], LoadSceneMode.Single);
    }
    public void StartContinueToNextScene()
    {
        StartCoroutine(ContinueToNextScene());
    }
    public IEnumerator ContinueToNextScene()
    {
        UIManager.Instance.StartTransition();
        yield return new WaitForSeconds(transitionTime);
        sceneIdx = PlayerPrefs.GetInt("Level", 0);
        sceneIdx %= scenes.Length;
        if (sceneIdx == 0)
        {
            sceneIdx++;
        }
        PlayerPrefs.SetInt("Level", sceneIdx);
        SceneManager.LoadScene(scenes[sceneIdx], LoadSceneMode.Single);
    }
    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public IEnumerator ReturnMenu()
    {
        UIManager.Instance.StartTransition();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public IEnumerator OpenHighScoresMenu()
    {
        UIManager.Instance.StartTransition();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scenes.Length-1, LoadSceneMode.Single);
    }
}