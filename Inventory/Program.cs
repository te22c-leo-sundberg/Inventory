using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

Character player = new() { Hp = 15, Name = "John", CarryCapacity = 4.5f };
Weapon sword = new() { Name = "Shobby Sword", Weight = 3.5f, MinDamage = 2, MaxDamage = 5 };
Consumable potion = new() { Name = "Healing Juice", Weight = 0.5f, MaxUses = 5, CurrentUses = 5 };
Inventory i = new();

i.Items.Add(sword);
i.Items.Add(potion);

Armour helmet = new(){Name = "Spikey Hat", Weight = 2.5f, Protection = 0.7f};

i.Display();


Console.WriteLine($"You stumble upon a {helmet.Name}, do you want to pick it up? Y/N");
string input = Console.ReadLine().ToUpper();

if (input == "Y")
{
    i.Items.Add(helmet);
    i.Display();
    i.WeightCheck(player.CurrentCarryWeight);
}
else if (input == "N")
{
    i.Display();
}

Console.ReadLine();