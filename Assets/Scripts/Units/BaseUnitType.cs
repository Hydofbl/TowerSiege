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
    public BoxCollider2D boxCollider2D;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer healthFiller;
    public float currentHealth;
    public ArrowManager arrowManager;
    public BaseUnitType(int health, float movementSpeed, int cost, Vector3 direction)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
        this.cost = cost;
        this.direction = direction;
    }
    private void Start()
    {
        currentHealth = health;
        arrowManager = FindObjectOfType<ArrowManager>();
    }
    public IEnumerator Move()
    {
        yield return new WaitForFixedUpdate();
        if (isMoving)
        {
            if(!arrowManager)
                arrowManager = FindObjectOfType<ArrowManager>();

            rb.velocity = direction * arrowManager.currentSpeed;
            StartCoroutine(Move());
        }
        else
            rb.velocity = Vector3.zero;
    }
    public void StartMove()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(Move());
        }
    }
    public void StopMove()
    {
        isMoving = false;
    }
    public void Flip(bool value)
    {
        spriteRenderer.flipX = value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WayPoint"))
        {
            direction = collision.GetComponent<WayPoint>().GetDirection(this);
        }
    }
    public void ChangeHealth(float value)
    {
        if(currentHealth+value<=0)
        {
            Destroy(gameObject);
        }
        else if(currentHealth+value>health)
        {
            currentHealth = health;
            healthFiller.size = new Vector2((float)(currentHealth / health) * 4.1f, 1);
        }
        else {
            currentHealth += value;
            healthFiller.size = new Vector2((float)(currentHealth / health) * 4.1f, 1);
        }
    }
}
