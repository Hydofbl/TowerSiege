using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameObject asker;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (asker.transform.position.x<transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX=true;
        }
        else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("degdi");
        
    }

}

