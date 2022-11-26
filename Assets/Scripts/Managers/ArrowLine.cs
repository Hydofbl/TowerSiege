using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLine : MonoBehaviour
{
    public float moveSpeed;
    public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-1, 0, 0) * moveSpeed, Time.deltaTime * 10);
        }
    }
}
