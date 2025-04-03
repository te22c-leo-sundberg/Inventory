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
List<Map> maps = new List<Map>();

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
// i.Display();

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

//Skapa ett sätt att genom att trycka Enter kunna generera flera maps
//Skapa förflyttning för spelaren på kartan
//Testa ifall MakePath() fungerar.
//Gör så att rummen blir till olika versioner som Enemy rum, Treasure rum etc.
//Test movement correction
//
Map m = new Map(); // Maybe switch this to a dictionary.
m.GenerateMap();
maps.Add(m);
player.playerX = m.startPosX;
player.playerY = m.startPosY;
m.PrintMap(player.playerY, player.playerX);

bool testing = true;
// Movement();

while (testing)
{
    // Console.Clear();

    int input = GetInt("Do you wish to Move [1], Dig [2] or Get Information [3]", 1, 3);
    if (input == 1)
    {
        Movement();
    }
    else if (input == 2)
    {
        m.MakePath(GetDirection(), player.playerX, player.playerY);
    }
    else if (input == 3)
    {
        Console.WriteLine("Haha");
    }


    m.PrintMap(player.playerY, player.playerX);
    Console.WriteLine("Move using the arrow keys, if you require any additional information, press [H]");

    // }
    // Console.WriteLine(maps);
}

// m.MakePath("right", player.playerX, player.playerY);

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
string GetDirection()
{
    bool success = false;
    while (!success)
    {
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            success = true;
            return "Down";
        }
        else if (key == ConsoleKey.UpArrow)
        {
            success = true;
            return "Up";
        }
        else if (key == ConsoleKey.LeftArrow)
        {
            success = true;
            return "Left";
        }
        else if (key == ConsoleKey.RightArrow)
        {
            success = true;
            return "Right";
        }
    }
    return "";
}
void Movement()
{
    bool success = false;
    while (!success)
    {
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.DownArrow)
        {
            MoveDirection(0, 1, "Down"); //Moves the character down once on the map.
        }
        else if (key == ConsoleKey.UpArrow)
        {
            MoveDirection(0, -1, "Up"); //Moves the character up once on the map.
        }
        else if (key == ConsoleKey.RightArrow)
        {
            MoveDirection(1, 0, "Right"); //Moves the character right once on the map.
        }
        else if (key == ConsoleKey.LeftArrow)
        {
            MoveDirection(-1, 0, "Left"); //Moves the character left once on the map.
        }
    }
    void MoveDirection(int moveX, int moveY, string direction)
    {
        if (m.MovementCorrection(player.playerX, player.playerY, moveX, moveY))
        {
            // Console.WriteLine(direction);
            player.playerX += moveX;
            player.playerY += moveY;
            success = true;
        }
    }
}
