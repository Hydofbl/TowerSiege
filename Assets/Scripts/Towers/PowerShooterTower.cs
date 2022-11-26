using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShooterTower : BaseTowerType
{
    public int attackLimit;
    [HideInInspector] public int currentAttackIndex;
    public PowerShooterTower(float attackSpeed, int attackPower, int range) : base(attackSpeed, attackPower, range)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            if (collision.GetComponent<BaseUnitType>().type == BaseUnitType.UnitType.Slower)
            {
                slowerUnits.Add(collision.GetComponent<SlowerUnit>());
                if (!isFiring)
                {
                    isFiring = true;
                    fireCoroutine = StartCoroutine(Fire());
                }
            }
            else
            {
                units.Add(collision.GetComponent<BaseUnitType>());
                if (!isFiring)
                {
                    isFiring = true;
                    fireCoroutine = StartCoroutine(Fire());
                }
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
            if (collision.GetComponent<BaseUnitType>().type == BaseUnitType.UnitType.Slower)
                slowerUnits.Remove(collision.GetComponent<SlowerUnit>());
            else
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
    protected override IEnumerator Fire()
    {
        while (!canAttack)
        {
            yield return new WaitForEndOfFrame();
        }
        if ((slowerUnits.Count > 0 || units.Count > 0) && isFiring && currentAttackIndex<attackLimit)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, bulletInstantiatePoint.transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().bulletPower = attackPower;
            if (slowerUnits.Count > 0)
            {
                while (slowerUnits[0] == null)
                {
                    slowerUnits.RemoveAt(0);
                }
                bulletGO.GetComponent<Bullet>().targetObject = slowerUnits[0].gameObject;
            }
            else
            {
                while (units[0] == null)
                {
                    units.RemoveAt(0);
                }
                bulletGO.GetComponent<Bullet>().targetObject = units[0].gameObject;
            }

            AssignCanAttack();

            currentAttackIndex++;
            yield return new WaitForSeconds(currentAttackSpeed);
            fireCoroutine = StartCoroutine(Fire());
        }
    }
}
