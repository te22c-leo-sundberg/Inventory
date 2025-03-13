using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

string weaponContents = File.ReadAllText("weapons.json");
string armourContents = File.ReadAllText("armours.json");
string manaConsumableContents = File.ReadAllText("manaConsumables.json");
string healthConsumableContents = File.ReadAllText("healthConsumables.json");
string enemyContents = File.ReadAllText("healthConsumables.json");

Map m = new();
List<Weapon> weapons = JsonSerializer.Deserialize<List<Weapon>>(weaponContents);
List<Armour> armours = JsonSerializer.Deserialize<List<Armour>>(armourContents);
List<Consumable> manaConsumables = JsonSerializer.Deserialize<List<Consumable>>(manaConsumableContents);
List<Consumable> healthConsumables = JsonSerializer.Deserialize<List<Consumable>>(healthConsumableContents);
List<Consumable> enemies = JsonSerializer.Deserialize<List<Consumable>>(enemyContents);

bool playing = true;
string scene = "";
bool battle = false;
bool treasure = false;
bool rest = false;

Character player = new("John", 15, 25, 4.5f);
Inventory i = new();
Armour helmet = new("Spikey Hat", 2.5f, 0.7f, 0.2f, 2);

i.Items.Add(weapons[1]);
i.Items.Add(healthConsumables[1]);

i.Display();

// Console.WriteLine($"You stumble upon a {helmet.Name}, do you want to pick it up? Y/N");
// string input = Console.ReadLine().ToUpper();

// if (input == "Y")
// {
//     bool success = i.AddItem(helmet, player.CarryCapacity);
//     if (success)
//     {
//         i.Display();
//     }
//     else
//     {
//         Console.WriteLine("Your inventory is full!");
//     }
// }
// else if (input == "N")
// {
//     i.Display();
// }
// time based combat where the player gets a different set amount of seconds where the enemies have a gap
//in defese. this lets attack speed be relevant

// while (playing)
// {
//     int choice = GetInt("What would you like to do? \n[1] Explore\n[2] Rest\n[3] Exit", 1, 3);
//     if (choice == 1)
//     {
//         Console.WriteLine("You explored!");
//     }
//     else if (choice == 2)
//     {
//         Console.WriteLine("You rested!");
//     }
//     else
//     {
//         Console.WriteLine("You left!");
//     }
// }

m.PrintMap();

Console.ReadLine();

int GetInt(string text, int minNum, int maxNum)
{
    Console.WriteLine(text);
    int output = 0;
    bool success = false;
    while (!success)
    {
        string input = Console.ReadLine();
        success = int.TryParse(input, out output);
        if (output < minNum)
        {
            Console.WriteLine("Too low of a number!");
            success = false;
        }
        else if (output > maxNum)
        {
            Console.WriteLine("Too high of a number!");
            success = false;
        }
    }
    return output;
}