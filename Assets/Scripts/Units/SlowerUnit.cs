using UnityEngine;

public class SlowerUnit : BaseUnitType
{
    public int slowingRange;
    public float slowingAmount; // ? Y�zde olarak m� indirelim yoksa miktar olarak m�? Miktar olacaksa int'e �evrilebilirler

    public SlowerUnit(int health, float movementSpeed, int cost, Vector3 direction) : base(health, movementSpeed, cost, direction)
    {
    }

    public void Slowdown()
    {

    }
}
