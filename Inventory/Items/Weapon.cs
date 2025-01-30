using System;
using System.Numerics;

public class Weapon : Item
{
    private int MinDamage;
    private int MaxDamage;

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }
    public Weapon (string name, float weight, int MinDmg, int MaxDmg)
    {
        Name = name;
        Weight = weight;
        MinDamage = MinDmg;
        MaxDamage = MaxDmg;
    }
}