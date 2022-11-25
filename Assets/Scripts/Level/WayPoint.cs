using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public enum Direction { left,right,up,down}
    public Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetDirection()
    {
        if(direction==Direction.down)
        {
            return new Vector3(0, -1, 0);
        }
        else if (direction == Direction.up)
        {
            return new Vector3(0, 1, 0);
        }
        else if (direction == Direction.right)
        {
            return new Vector3(1, 0, 0);
        }
        else if (direction == Direction.left)
        {
            return new Vector3(-1, 0, 0);
        }
        return Vector3.zero;
    }
}
