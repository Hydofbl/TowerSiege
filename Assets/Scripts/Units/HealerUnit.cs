using UnityEngine;

public class HealerUnit : BaseUnitType
{
    public int healRange;
    public int healAmount;

    public HealerUnit(int health, float movementSpeed, int cost, Vector3 direction) : base(health, movementSpeed, cost, direction)
    {
    }

    public void Heal()
    {
        print(direction);
    }
}
