public class Character
{
    private string Name;
    public int Hp;
    public int Mana;
    public float CarryCapacity;
    private float CurrentCarryWeight;

    public Character(string name, int hp, int mana, float carryCap)
    {
        Name = name;
        Hp = hp;
        Mana = mana;
        CarryCapacity = carryCap;
        CurrentCarryWeight = 0;
    }

    public bool CanPickUp(float target)
    {
        if (CurrentCarryWeight +  target > CarryCapacity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}