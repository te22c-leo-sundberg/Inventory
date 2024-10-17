using System;
using System.Numerics;

public class Weapon : Item
{
    public int MinDamage;
    public int MaxDamage;

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }
}