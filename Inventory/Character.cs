public class Character
{
    public int Hp;
    public string Name;
    public float CarryCapacity;
    public float CurrentCarryWeight;
    public bool ItemPickup = true;

    public void CarryCheck()
    {
        if (CarryCapacity > CurrentCarryWeight)
        {
            ItemPickup = false;
        }
        else {ItemPickup = true;}
    }
}