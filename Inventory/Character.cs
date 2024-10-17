public class Character
{
    public int Hp;
    public string Name;
    public float CarryCapacity;
    public float CurrentCarryWeight;

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