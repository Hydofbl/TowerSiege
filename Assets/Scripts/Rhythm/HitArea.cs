using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    public Arrows arrowInArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (arrowInArea)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                arrowInArea.GetComponent<Arrows>().CheckArrow(KeyCode.UpArrow);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && arrowInArea)
            {
                arrowInArea.GetComponent<Arrows>().CheckArrow(KeyCode.RightArrow);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && arrowInArea)
            {
                arrowInArea.GetComponent<Arrows>().CheckArrow(KeyCode.DownArrow);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && arrowInArea)
            {
                arrowInArea.GetComponent<Arrows>().CheckArrow(KeyCode.LeftArrow);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ArrowParent"))
        {
            arrowInArea = collision.GetComponent<Arrows>();
        }
    }

}
