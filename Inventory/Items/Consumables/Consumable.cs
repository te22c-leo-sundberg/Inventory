using System.Text.Json.Serialization;

public class Consumable : Item
{
    [JsonInclude] public int MaxUses;
    [JsonInclude] public int CurrentUses;
    [JsonInclude] public float ConsumableStrength;
    public void UseConsumable(Character target)
    {
        if (CurrentUses > 0)
        {
            target.Hp += 10;
            CurrentUses --;
        }
    }
}