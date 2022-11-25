using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnitType: MonoBehaviour
{
    public enum UnitType
    {
        Normy,
        Healer,
        Slower
    };

    public UnitType type;

    public int health;
    public float movementSpeed;
    public int cost;
    public Vector3 direction;
    public bool isMoving;
    public Rigidbody2D rb;
    public BaseUnitType(int health, float movementSpeed, int cost, Vector3 direction)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
        this.cost = cost;
        this.direction = direction;
    }

    public IEnumerator Move()
    {
        yield return new WaitForFixedUpdate();
        if (isMoving)
            rb.velocity = direction * movementSpeed;
        else
            rb.velocity = Vector3.zero;
        StartCoroutine(Move());
    }
    public void StartMove()
    {
        isMoving = true;
        StartCoroutine(Move());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WayPoint"))
        {
            print(1);
            direction = collision.GetComponent<WayPoint>().GetDirection();
        }
    }
}
