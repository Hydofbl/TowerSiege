using UnityEngine;

public class HealerUnit : BaseUnitType
{
    public int healRange;
    public int healAmount;

    public HealerUnit(int health, float movementSpeed, int cost, Vector3 direction) : base(health, movementSpeed, cost, direction)
    {
    }

    private void Update()
    {
        Move();
        Heal();
    }

    public void Heal()
    {
        print(direction);
    }
}
