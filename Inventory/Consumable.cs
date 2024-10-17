public class Consumable : Item
{
    public int MaxUses;
    public int CurrentUses;
    
    public void UseConsumable(Character target)
    {
        if (CurrentUses > 0)
        {
            target.Hp += 10;
            CurrentUses --;
        }
    }
}