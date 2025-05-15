using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

string weaponContents = File.ReadAllText("weapons.json");
string armourContents = File.ReadAllText("armours.json");
string manaConsumableContents = File.ReadAllText("manaConsumables.json");
string healthConsumableContents = File.ReadAllText("healthConsumables.json");
string enemyContents = File.ReadAllText("healthConsumables.json");

// Map m = new();

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
MapMover m = new();
Character player = new("John", 15, 25, 4.5f);
Inventory i = new();
Armour helmet = new("Spikey Hat", 2.5f, 0.7f, 0.2f, 2);

i.Items.Add(weapons[1]);
i.Items.Add(healthConsumables[1]);

bool testing = true;
bool start = true;

while (testing)
{
    Console.Clear();
    if (start) //Move this to MapMover.cs
    {
        m.StartGame();
        start = false;
    }

    m.maps[m.GetCurrentFloor()].PrintMap(m.GetPlayerY(), m.GetPlayerX());
    
    int input = GetInt("Do you wish to Do Nothing [0], Move [1], Dig [2] or Descend [3]", 0, 3);
    if (input == 0)
    {
    }
    else if (input == 1)
    {
        m.Movement();
    }
    else if (input == 2)
    {
        m.maps[m.GetCurrentFloor()].MakePath(m.GetDirection(), m.GetPlayerX(), m.GetPlayerY());
    }
    else if (input == 3)
    {
        m.Descend();
    }

    Console.WriteLine("Move using the arrow keys, if you require any additional information, press [H]");
}

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