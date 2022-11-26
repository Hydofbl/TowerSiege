using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStates : MonoBehaviour
{
    public KeyCode up, down, right, left;

    public bool upRight, upLeft, upDown, downRight, downLeft, rightLeft;

    private void Update()
    {
        if (Input.GetKeyDown(up) && Input.GetKeyDown(right))
            upRight = true;
    }
}
