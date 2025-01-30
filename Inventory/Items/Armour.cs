public class Armour : Item
{
    private float Protection;
    private float Speed;
    public Armour (string name, float weight, float prot, float speed)
    {
        Name = name;
        Weight = weight;
        Protection = prot;
        Speed = speed;
    }
}