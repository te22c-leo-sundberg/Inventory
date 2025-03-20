class Map
{
    public int[,] mapData = //Checka dictionaries
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    public void GenerateMap()
    {
        int maxPaths = 15;
        int pathCount = 0;
        GeneratePaths(pathCount, maxPaths);
        CheckNeighbours(2, 3, 0);
        CheckNeighboursNumber(3, 2, 0, 1);
    }

    public void PrintMap(int playerY, int playerX)
    {
        // string[] emojiMap = { "  ", "  ", "🈵", "🈳", "↕️", "↔️", "➕", "🈹", "🈯", "✴️", "⚜️" };
        // string[] emojiMap = { "  ", "  ", "🈵", "🈳", "➕", "🈹", "🈯", "✴️", "⚜️" };
        string[] emojiMap = { "  ", " E", " O", " +" };
        string output;
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                output = emojiMap[mapData[y, x]];
                if (y == playerY && x == playerX)
                {
                    Console.Write(" X");
                }
                else
                {
                    Console.Write(output);
                }
            }
            Console.Write("\n");
        }
    }

    void MovementCorrection(int playerX, int playerY)
    {
        if (playerX > 7)
        {
            playerX = 7;
        }
        else if (playerX < 1)
        {
            playerX = 1;
        }
        if (playerY > 7)
        {
            playerY = 7;
        }
        else if (playerY < 1)
        {
            playerY = 1;
        }
    }

    int CheckCollision(int playerX, int playerY)
    {
        if (mapData[playerY, playerX] != 1 && mapData[playerY, playerX] != 0)
        {
            if (mapData[playerY, playerX] == 4)
                return 1;
        }
        return 0;
    }

    public void MakePath(string direction, int playerX, int playerY)
    {
        if (mapData[playerY, playerX] == 2)
        {
            if (direction == "left")
            {
                if (playerX != 1)
                {
                    if (mapData[playerY, playerX - 2] != 0 && mapData[playerY, playerX - 2] > 3)
                    {
                        mapData[playerY, playerX - 1] = 3;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "right")
            {
                if (playerX != 7)
                {
                    if (mapData[playerY, playerX + 2] != 0 && mapData[playerY, playerX + 2] > 3)
                    {
                        mapData[playerY, playerX + 1] = 3;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "up")
            {
                if (playerY != 1)
                {
                    if (mapData[playerY - 2, playerX] != 0 && mapData[playerY - 2, playerX] > 3)
                    {
                        mapData[playerY - 1, playerX] = 3;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "down")
            {
                if (playerX != 7)
                {
                    if (mapData[playerY + 2, playerX] != 0 && mapData[playerY + 2, playerX] > 3)
                    {
                        mapData[playerY + 1, playerX] = 3;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
        }

    }
void GeneratePaths(int pathCount, int maxPaths)
{
    for (int y = 0; y < mapData.GetLength(0); y++) //
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == 1)
                {
                    int pathChance = Random.Shared.Next(1, 10);
                    if (pathChance > 4 && pathCount <= maxPaths)
                    {
                        pathCount++;
                        if (mapData[y, x] == 1)
                        {
                            mapData[y, x] = 3;
                        }
                    }
                    else
                    {
                        if (mapData[y, x] == 1)
                        {
                            mapData[y, x] = 0;
                        }
                    }
                }
            }
        }
}
    void CheckNeighbours(int checkData, int neighbourData, int newData)
    {
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == checkData)
                {
                    if (
                        mapData[y - 1, x] != neighbourData
                        && mapData[y + 1, x] != neighbourData
                        && mapData[y, x - 1] != neighbourData
                        && mapData[y, x + 1] != neighbourData
                    )
                    {
                        mapData[y, x] = newData;
                    }
                }
            }
        }
    }
    void CheckNeighboursNumber(int checkData, int neighbourData, int newData, int countReq)
    {
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == checkData)
                {
                    int count = 0;
                    if (mapData[y - 1, x] == neighbourData)
                    {
                        count++;
                    }
                    if (mapData[y + 1, x] == neighbourData)
                    {
                        count++;
                    }
                    if (mapData[y, x - 1] == neighbourData)
                    {
                        count++;
                    }
                    if (mapData[y, x + 1] == neighbourData)
                    {
                        count++;
                    }
                    if (count <= countReq)
                    {
                        mapData[y, x] = newData;
                    }
                }
            }
        }
    }
}
