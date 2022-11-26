using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public string[] arrowList;
    public GameObject arrowInstantiatePoint;
    public GameObject arrowParentPrefab;
    public Vector3 offset;
    public float movementSpeed;
    public float movementSpeedCorrectMultiplier;
    public int comboIndex;
    public float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        for (int i = 0; i < arrowList.Length; i++)
        {
            GameObject arrowGO = Instantiate(arrowParentPrefab, arrowInstantiatePoint.transform);
            arrowGO.transform.position += offset * index;
            arrowGO.GetComponent<Arrows>().arrowType = arrowList[index];
            arrowGO.GetComponent<Arrows>().InstantiateVisuals();
            index++;
        }
        FindObjectOfType<ArrowLine>().isMove = true;
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Correct()
    {
        currentSpeed = movementSpeed + movementSpeedCorrectMultiplier * comboIndex;
        foreach (BaseUnitType baseUnitType in FindObjectsOfType<BaseUnitType>())
        {
            baseUnitType.StartMove();
        }
        comboIndex++;
    }
    public void Wrong()
    {
        currentSpeed = 0;
        comboIndex = 0;
        foreach (BaseUnitType baseUnitType in FindObjectsOfType<BaseUnitType>())
        {
            baseUnitType.StopMove();
        }
    }
}
