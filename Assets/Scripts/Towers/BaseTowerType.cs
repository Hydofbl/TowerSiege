using UnityEngine;

public class BaseTowerType : MonoBehaviour
{
    public float attackSpeed;
    public int attackPower;
    public int range;

    public BaseTowerType(float attackSpeed, int attackPower, int range)
    {
        this.attackSpeed = attackSpeed;
        this.attackPower = attackPower;
        this.range = range;
    }
}
