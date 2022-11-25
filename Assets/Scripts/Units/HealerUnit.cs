using UnityEngine;

public class HealerUnit : NormyUnit
{
    public int healRange;
    public int healAmount;

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
