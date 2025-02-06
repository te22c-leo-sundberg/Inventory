using System.Text.Json.Serialization;

public class Armour : Item
{
    [JsonInclude] private float Protection;
    [JsonInclude] private float Speed;
    [JsonInclude] private int AttackBoost;
    public Armour (string name, float weight, float prot, float speed, int atkBoost)
    {
        Name = name;
        Weight = weight;
        Protection = prot;
        Speed = speed;
        AttackBoost = atkBoost;
    }
}