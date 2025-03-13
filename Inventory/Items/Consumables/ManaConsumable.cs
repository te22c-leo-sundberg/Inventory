public class ManaConsumable : Consumable
{
    public ManaConsumable () { }
    public ManaConsumable (string name, float weight, int maxUses, float conStr)
    {
        Name = name;
        Weight = weight;
        MaxUses = maxUses;
        CurrentUses = maxUses;
        ConsumableStrength = conStr;
    }
    public void UseManaConsumable(Character target)
    {
        if (CurrentUses > 0)
        {
            target.Mana += 10;
            CurrentUses --;
        }
    }
}