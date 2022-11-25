using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskerMovement : MonoBehaviour
{
    Rigidbody2D fizik;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fizik.velocity = new Vector2(-1,0);
    }
}
