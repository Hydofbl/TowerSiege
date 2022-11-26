using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public BaseUnitType[] unitsThatSpawn;
    public GameObject unitSpawnPoint;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.height / (float)Screen.width;
        float scalefactor;
        if (windowaspect >= targetaspect)
        {
            scalefactor = windowaspect / targetaspect;
            Camera.main.orthographicSize = Camera.main.orthographicSize * scalefactor;
        }
        int index = 0;
        foreach(BaseUnitType baseUnit in unitsThatSpawn)
        {
            BaseUnitType instantiatedUnit =  Instantiate(unitsThatSpawn[index], unitSpawnPoint.transform.position+(offset*index), Quaternion.identity);
            index++;
            instantiatedUnit.StartMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
