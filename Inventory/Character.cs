public class Character
{
    public int Hp;
    public string Name;
    public float CarryCapacity;
    public float CurrentCarryWeight;
    public bool CanPickUp = true;

    public void CarryCheck()
    {
        if (CarryCapacity > CurrentCarryWeight)
        {
            CanPickUp = false;
        }
        else {CanPickUp = true;}
    }
}