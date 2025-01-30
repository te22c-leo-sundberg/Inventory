public class Character
{
    private string Name;
    public int Hp;
    public float CarryCapacity;
    private float CurrentCarryWeight;

    public Character(string name, int hp, float carryCap)
    {
        Name = name;
        Hp = hp;
        CarryCapacity = carryCap;
        CurrentCarryWeight = 0;
    }

    public bool CanPickUp()
    {
        if (CurrentCarryWeight > CarryCapacity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}