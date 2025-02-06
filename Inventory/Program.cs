using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

Character player = new("John", 15, 4.5f);
Weapon sword = new ("Shobby Sword", 3.5f, 1.0f, 2,  5);
HealthConsumable potion = new("Healing Juice", 0.5f, 5, 1.0f);
Inventory i = new();

Armour helmet = new("Spikey Hat", 2.5f, 0.7f, 0.2f, 2);

string armourJson = JsonSerializer.Serialize(potion);

File.WriteAllText("manaConsumables.json", armourJson);

string weaponContents = File.ReadAllText("weapons.json");
string armourContents = File.ReadAllText("armours.json");
string manaConsumablesContents = File.ReadAllText("manaConsumables.json");
string healthConsumableContents = File.ReadAllText("healthConsumables.json");


// List<Weapon> w = JsonSerializer.Deserialize<List<Weapon>>(weaponContents);
// List<Armour> a = JsonSerializer.Deserialize<List<Armour>>(armourContents);
// List<Consumable> c = JsonSerializer.Deserialize<List<Consumable>>(consumablesContents);

i.Items.Add(sword);
i.Items.Add(potion);



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
// time based combat where the player gets a different set amount of seconds where the enemies have a gap
//in defese. this lets attack speed be relevant


Console.ReadLine();