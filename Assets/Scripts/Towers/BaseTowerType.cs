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
    public List<BaseUnitType> units = new List<BaseUnitType>();
    public bool isFiring;
    public Coroutine fireCoroutine;
    public bool canAttack = true;
    public float currentAttackSpeed;
    public List<SlowerUnit> slowerUnits = new List<SlowerUnit>();

    public BaseTowerType(float attackSpeed, int attackPower, int range)
    {
        this.attackSpeed = attackSpeed;
        this.attackPower = attackPower;
        this.range = range;
    }
    private void Start()
    {
        circleCollider2D.radius = range;
        currentAttackSpeed = attackSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            units.Add(collision.GetComponent<BaseUnitType>());
            if (!isFiring)
            {
                isFiring = true;
                fireCoroutine = StartCoroutine(Fire());
            }

        }
        else if (collision.CompareTag("SlowerArea"))
        {
            slowerUnits.Add(collision.GetComponentInParent<SlowerUnit>());
            CheckIsThereSlowerUnits();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            units.Remove(collision.GetComponent<BaseUnitType>());
            CheckUnits();
            CheckIsThereSlowerUnits();
        }
        else if (collision.CompareTag("SlowerArea"))
        {
            slowerUnits.Remove(collision.GetComponentInParent<SlowerUnit>());
            CheckIsThereSlowerUnits();
        }
    }
    protected virtual IEnumerator Fire()
    {
        while (!canAttack)
        {
            yield return new WaitForEndOfFrame();
        }
        if (units.Count > 0 && isFiring)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, bulletInstantiatePoint.transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().bulletPower = attackPower;
            while (units[0] == null)
            {
                units.RemoveAt(0);
            }
            bulletGO.GetComponent<Bullet>().targetObject = units[0].gameObject;
            AssignCanAttack();

            yield return new WaitForSeconds(currentAttackSpeed);
            fireCoroutine = StartCoroutine(Fire());
        }

    }
    public void AssignCanAttack()
    {
        canAttack = false;
        StartCoroutine(WaitForCanAttack());
    }
    public IEnumerator WaitForCanAttack()
    {
        yield return new WaitForSeconds(currentAttackSpeed);
        canAttack = true;

    }
    public void CheckUnits()
    {
        if (units.Count <= 0)
        {
            isFiring = false;
            StopCoroutine(fireCoroutine);
        }

    }
    public void CheckIsThereSlowerUnits()
    {
        while (slowerUnits.Count > 0 && slowerUnits[0] == null)
        {
            slowerUnits.RemoveAt(0);
        }
        if (slowerUnits.Count > 0)
        {
            currentAttackSpeed = attackSpeed * slowerUnits[0].GetComponent<SlowerUnit>().slowingAmount;
        }
        else
            currentAttackSpeed = attackSpeed;
    }
}
