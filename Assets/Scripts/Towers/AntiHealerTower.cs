using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiHealerTower : BaseTowerType
{
    public List<HealerUnit> healerUnits = new List<HealerUnit>();
    public AntiHealerTower(float attackSpeed, int attackPower, int range) : base(attackSpeed, attackPower, range)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            if (collision.GetComponent<BaseUnitType>().type == BaseUnitType.UnitType.Healer)
            {
                healerUnits.Add(collision.GetComponent<HealerUnit>());
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
            if (collision.GetComponent<BaseUnitType>().type == BaseUnitType.UnitType.Healer)
                healerUnits.Remove(collision.GetComponent<HealerUnit>());
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
        if ((healerUnits.Count>0 || units.Count > 0) && isFiring)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, bulletInstantiatePoint.transform.position, Quaternion.identity);
            bulletGO.GetComponent<Bullet>().bulletPower = attackPower;
            if (healerUnits.Count>0)
            {
                while (healerUnits[0] == null)
                {
                    healerUnits.RemoveAt(0);
                }
                    bulletGO.GetComponent<Bullet>().targetObject = healerUnits[0].gameObject;
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


            yield return new WaitForSeconds(currentAttackSpeed);
            fireCoroutine = StartCoroutine(Fire());
        }
    }
}
