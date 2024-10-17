public class Inventory
{
    public List<Item> Items = [];

    public void Display()
    {
        Console.WriteLine("Your inventory contains:");
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i+1}) {Items[i].Name}");
        }
    }
    public void WeightCheck(float n)
    {
        n = Items.Sum(item => item.Weight);

        // for (int i = 0; i < Items.Count; i++)
        // {
        //     n += Items[i].Weight;
        // }
        Console.WriteLine("" + n);
    }
}