using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerType : MonoBehaviour
{
    public float attackSpeed;
    public int attackPower;
    public int range;
    public CircleCollider2D circleCollider2D;
    public GameObject bulletPrefab;
    public GameObject bulletInstantiatePoint;
    public List<BaseUnitType> units=new List<BaseUnitType>();
    public bool isFiring;
    public Coroutine fireCoroutine;
    public BaseTowerType(float attackSpeed, int attackPower, int range)
    {
        this.attackSpeed = attackSpeed;
        this.attackPower = attackPower;
        this.range = range;
    }
    private void Start()
    {
        circleCollider2D.radius = range;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Unit"))
        {
            units.Add(collision.GetComponent<BaseUnitType>());
            if(!isFiring)
            {
                isFiring = true;
                fireCoroutine= StartCoroutine(Fire());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            units.Remove(collision.GetComponent<BaseUnitType>());
            CheckUnits();
            
        }
    }
    public IEnumerator Fire()
    {
        if(units.Count>0 && isFiring)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, bulletInstantiatePoint.transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().bulletPower = attackPower;
            while(units[0]==null)
            {
                units.RemoveAt(0);
            }
            bulletGO.GetComponent<Bullet>().targetObject = units[0].gameObject;
            yield return new WaitForSeconds(attackSpeed);
            fireCoroutine= StartCoroutine(Fire());
        }
    }
    public void CheckUnits()
    {
        if(units.Count<=0)
        {
            isFiring = false;
            StopCoroutine(fireCoroutine);
        }
        
    }
}
