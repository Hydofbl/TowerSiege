using UnityEngine;

public class NormyUnit : MonoBehaviour
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

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position + direction, Time.deltaTime * movementSpeed);
    }
}
