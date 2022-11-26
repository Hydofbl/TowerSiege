using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPressed;

    private string keyCode;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canBePressed)
            {
                if (keyCode.Equals(keyToPressed.ToString()))
                {
                    gameObject.SetActive(false);

                    GameManager.Instance.NoteHit();
                }
                else
                {
                    GameManager.Instance.NoteMissed();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;

            GameManager.Instance.NoteMissed();
        }
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && e.type == EventType.KeyDown)
        {
            keyCode = e.keyCode.ToString();
        }
    }
}
