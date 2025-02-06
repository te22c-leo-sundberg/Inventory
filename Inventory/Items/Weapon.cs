using System;
using System.Numerics;
using System.Text.Json.Serialization;

public class Weapon : Item
{
    [JsonInclude] private float AttackSpeed;
    [JsonInclude] private int MinDamage;
    [JsonInclude] private int MaxDamage;

    public int Attack()
    {
        return Random.Shared.Next(MinDamage, MaxDamage);
    }
    public Weapon (string name, float weight, float asp, int MinDmg, int MaxDmg)
    {
        Name = name;
        Weight = weight;
        AttackSpeed = asp;
        MinDamage = MinDmg;
        MaxDamage = MaxDmg;
    }
}