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

    public BaseUnitType(int health, float movementSpeed, int cost, Vector3 direction)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
        this.cost = cost;
        this.direction = direction;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position + direction, Time.deltaTime * movementSpeed);
    }
}
