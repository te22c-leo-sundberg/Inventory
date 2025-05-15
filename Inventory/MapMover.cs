class MapMover
{
    public List<Map> maps = new List<Map>();
    int playerX;
    int playerY;
    int currentFloor = 0;
    public void StartGame()
    {
        Map map = new Map();
        currentFloor = 0;
        map.GenerateMap();
        maps.Add(map);
        SetPlayerX(maps[GetCurrentFloor()].startPosX);
        SetPlayerY(maps[GetCurrentFloor()].startPosY);
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
    public void Descend()
    {
        Map map = new Map();
        currentFloor++;
        map.GenerateMap();
        maps.Add(map);
        playerX = maps[currentFloor].startPosX;
        playerY = maps[currentFloor].startPosY;
    }

    public MapMover()
    {

    }
}