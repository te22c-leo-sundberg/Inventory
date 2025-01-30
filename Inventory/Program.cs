using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

Character player = new("John", 15, 4.5f);
Weapon sword = new ("Shobby Sword", 3.5f, 2,  5);
Consumable potion = new("Healing Juice", 0.5f, 5);
Inventory i = new();

i.Items.Add(sword);
i.Items.Add(potion);

Armour helmet = new("Spikey Hat", 2.5f, 0.7f, 0.2f);

i.Display();


Console.WriteLine($"You stumble upon a {helmet.Name}, do you want to pick it up? Y/N");
string input = Console.ReadLine().ToUpper();

if (input == "Y")
{
    bool success = i.AddItem(helmet, player.CarryCapacity);
    if (success)
    {
        i.Display();
    }
    else
    {
        Console.WriteLine("Your inventory is full!");
    }    
    i.Discard();
}
else if (input == "N")
{
    i.Display();
}

Console.ReadLine();