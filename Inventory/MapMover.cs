using System.Text;

class MapMover
{
    public List<Map> maps = new List<Map>();
    int playerX;
    int playerY;
    int currentFloor = 0;
    bool start = true;
    public void GameLoop()
    {
        Console.Clear();
        if (start) //Move this to MapMover.cs
        {
            StartGame();
            start = false;
        }

        maps[GetCurrentFloor()].PrintMap(GetPlayerY(), GetPlayerX());
        int input = GetInt("Do you wish to Explore [0], Move [1], Dig [2], Descend [3] or Ascend [4]", 0, 4);
        if (input == 0)
        {
            int roomInput = 0;
            if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Path")
            {
                Console.WriteLine("There is no room here.");
            }
            else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Ascend")
            {
                Console.WriteLine("A half broken staircase.The reason you were able to go down here in the first place.");
                roomInput = GetInt("Would you like to Walk up the staircase [1] or Leave it be [2]?", 1, 2);
                if (input == 1)
                {

                }
                else if (input == 2)
                {

                }
            }
            else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Descend")
            {
                Console.WriteLine("A functional staircase.");
                roomInput = GetInt("Would you like to Walk down the staircase [1] or Leave it be [2]?", 1, 2);
            }
            else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Combat")
            {
                Console.WriteLine("You see a room, some gold and treasure lies at one part of it, but blocking it is what looks to be a monster.");

                roomInput = GetInt("Would you like to Enter the room [1] or Leave it be [2]?", 1, 2);
            }
            else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Treasure")
            {
                Console.WriteLine("You see a room filled with treasure, you got lucky for once in your miserable life.");
                roomInput = GetInt("Would you like to Enter the room [1] or Leave it be [2]?", 1, 2);
            }
            else if (maps[GetCurrentFloor()].PlayerPos(playerX, playerY) == "Rest")
            {
                Console.WriteLine("You see a room with a nice fountain, spouting constant water, lying next to it is a nice bed.");
                roomInput = GetInt("Would you like to Enter the room [1] or Leave it be [2]?", 1, 2);
            }
        }
        else if (input == 1)
        {
            Movement();
        }
        else if (input == 2)
        {
            maps[GetCurrentFloor()].MakePath(GetDirection(), GetPlayerX(), GetPlayerY());
        }
        else if (input == 3)
        {
            Descend();
        }
        else if (input == 4)
        {
            Ascend();
        }
    }
    public void StartGame()
    {
        Map map = new Map();
        currentFloor = 0;
        map.GenerateMap();
        maps.Add(map);
        SetPlayerX(maps[GetCurrentFloor()].posX);
        SetPlayerY(maps[GetCurrentFloor()].posY);
    }
    public string GetDirection()
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
    public int GetPlayerX()
    {
        return playerX;
    }
    public void SetPlayerX(int X)
    {
        playerX = X;
    }
    public int GetPlayerY()
    {
        return playerY;
    }
    public void SetPlayerY(int Y)
    {
        playerY = Y;
    }
    public int GetCurrentFloor()
    {
        return currentFloor;
    }
    public void Movement()
    {
        Console.WriteLine("Move using the arrow keys");
        bool success = false;
        while (!success)
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow)
            {
                MoveDirection(0, 1); //Moves the character down once on the map.
            }
            else if (key == ConsoleKey.UpArrow)
            {
                MoveDirection(0, -1); //Moves the character up once on the map.
            }
            else if (key == ConsoleKey.RightArrow)
            {
                MoveDirection(1, 0); //Moves the character right once on the map.
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                MoveDirection(-1, 0); //Moves the character left once on the map.
            }
        }
        void MoveDirection(int moveX, int moveY)
        {
            if (maps[currentFloor].IsOnPath(playerX, playerY, moveX, moveY))
            {
                playerX += moveX;
                playerY += moveY;
                success = true;
            }
            else
            {
                Console.WriteLine("You cannot move out of bounds!");
            }
        }
    }
    void Ascend()
    {
        maps[currentFloor].posX = playerX;
        maps[currentFloor].posY = playerY;
        if (currentFloor > 0)
        {
            Console.WriteLine("You ascend the staircase and end up in a familiar place.");
            currentFloor--;
            SetPlayerX(maps[currentFloor].posX);
            SetPlayerY(maps[currentFloor].posY);
        }
        else
        {
            Console.WriteLine("You're already at the top. Would you like to exit the game?");
        }
    }
    void Descend()
    {
        maps[currentFloor].posX = playerX;
        maps[currentFloor].posY = playerY;
        if (currentFloor == maps.Count - 1)
        {
            Map map = new Map();
            map.GenerateMap();
            maps.Add(map);
        }
        currentFloor++;
        playerX = maps[currentFloor].posX;
        playerY = maps[currentFloor].posY;
    }
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

    public MapMover()
    {

    }
}