using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButton : MonoBehaviour
{
    public UnitManager unitManager;
    public GameObject stackStartPoint;
    public GameObject healerPrefab, normiePrefab, slowerPrefab;
    public GameObject preparationParent;
    public float parentMoveSpeed;
    public GameObject rhythmParent;
    public ArrowManager arrowManager;
    // Start is called before the first frame update
    void Start()
    {
        unitManager = FindObjectOfType<UnitManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (stackStartPoint.transform.childCount > 0)
        {
            foreach (Transform tr in stackStartPoint.transform)
            {
                switch (tr.GetComponent<StackObjects>().type)
                {
                    case 0:
                        unitManager.unitsThatSpawn.Add(healerPrefab.GetComponent<BaseUnitType>());
                        break;
                    case 1:
                        unitManager.unitsThatSpawn.Add(normiePrefab.GetComponent<BaseUnitType>());
                        break;
                    case 2:
                        unitManager.unitsThatSpawn.Add(slowerPrefab.GetComponent<BaseUnitType>());
                        break;

                }
            }
            unitManager.SpawnUnits();
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(ParentMove());
            StartCoroutine(StartGame());
        }
    }
    public IEnumerator ParentMove()
    {
        preparationParent.transform.position = Vector3.Lerp(preparationParent.transform.position, preparationParent.transform.position 
            + new Vector3(0, -1* parentMoveSpeed, 0), Time.deltaTime * 10);
        yield return new WaitForEndOfFrame();
        StartCoroutine(ParentMove());
    }
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        rhythmParent.SetActive(true);
        rhythmParent.transform.DOMove(Vector3.zero, 1);
        FindObjectOfType<ArrowManager>().enabled = true;
        FindObjectOfType<UnitManager>().enabled = true;
        Destroy(preparationParent);
        Destroy(gameObject);
    }
}
