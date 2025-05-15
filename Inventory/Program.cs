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
    m.GameLoop();
}

Console.ReadLine();

