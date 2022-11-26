using System.Collections;
using UnityEngine;

public class HealerUnit : BaseUnitType
{
    public float healRange;
    public int healAmount;
    public float healTime;

    public HealerUnit(int health, float movementSpeed, int cost, Vector3 direction) : base(health, movementSpeed, cost, direction)
    {
    }
    private void Start()
    {
        currentHealth = health;
        StartCoroutine(Heal());
    }

    public IEnumerator Heal()
    {
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, healRange);
        Debug.Log("enter", gameObject);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Unit"))
            {
        Debug.Log(hitCollider.name, hitCollider.gameObject);

                hitCollider.GetComponent<BaseUnitType>().ChangeHealth(healAmount);
            }
        }
        yield return new WaitForSeconds(healTime);
        StartCoroutine(Heal());
    }
}
