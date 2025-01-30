public class Consumable : Item
{
    public int MaxUses;
    public int CurrentUses;
    
    public Consumable (string name, float weight, int maxUses)
    {
        Name = name;
        Weight = weight;
        MaxUses = maxUses;
        CurrentUses = maxUses;
    }
    public void UseConsumable(Character target)
    {
        if (CurrentUses > 0)
        {
            target.Hp += 10;
            CurrentUses --;
        }
    }
}