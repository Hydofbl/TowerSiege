using UnityEngine;

public class SlowerUnit : BaseUnitType
{
    public int slowingRange;
    public float slowingAmount; // ? Yüzde olarak mý indirelim yoksa miktar olarak mý? Miktar olacaksa int'e çevrilebilirler

    public SlowerUnit(int health, float movementSpeed, int cost, Vector3 direction) : base(health, movementSpeed, cost, direction)
    {
    }

    public void Slowdown()
    {

    }
}
