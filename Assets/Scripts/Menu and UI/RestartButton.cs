using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //StartCoroutine(RestartLevel());
    }
    /*public IEnumerator RestartLevel()
    {

        UIManager.Instance.StartTransition();
        yield return new WaitForSeconds(0.5f);
        movement.Restart();
        transform.parent = movement.transform;
        transform.localPosition = Vector3.zero;
        foreach (MovingObject movingObject in FindObjectsOfType<MovingObject>())
        {
            movingObject.Restart();
        }
        gameObject.SetActive(false);
        UIManager.Instance.EndTransition();
        yield return new WaitForSeconds(0.5f);
    }*/
}
