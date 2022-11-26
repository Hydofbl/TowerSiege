using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer sR;
    public Sprite defImg;
    public Sprite pressedImg;

    public KeyCode up, down, left, right;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up) || Input.GetKeyDown(down) ||
            Input.GetKeyDown(left) || Input.GetKeyDown(right))
        {
            sR.sprite = pressedImg;
        }

        if (Input.GetKeyUp(up) || Input.GetKeyUp(down) ||
            Input.GetKeyUp(left) || Input.GetKeyUp(right))
        {
            sR.sprite = defImg;
        }
    }
}
