public class HealthConsumable : Consumable
{
    public HealthConsumable (string name, float weight, int maxUses, float conStr)
    {
        Name = name;
        Weight = weight;
        MaxUses = maxUses;
        CurrentUses = maxUses;
        ConsumableStrength = conStr;
    }
    public void UseHealthConsumable(Character target)
    {
        if (CurrentUses > 0)
        {
            target.Hp += 10;
            CurrentUses --;
        }
    }
}