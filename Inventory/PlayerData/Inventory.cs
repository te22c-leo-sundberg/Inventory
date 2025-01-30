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
    public void WeightCheck()
    {
        float n = Items.Sum(item => item.Weight);
        Console.WriteLine(n);
    }
    public bool AddItem(Item item, float capacity)
    {
        float n = Items.Sum(item => item.Weight);
        if (n + item.Weight > capacity)
        {
            return false;
        }
        else
        {
            Items.Add(item);
            return true;
        }
    }
}