using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShooterTower : BaseTowerType
{
    public int attackLimit;

    public PowerShooterTower(float attackSpeed, int attackPower, int range) : base(attackSpeed, attackPower, range)
    {
    }
}
