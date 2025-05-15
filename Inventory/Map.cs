class Map
{
    int maxPaths = 15;
    int pathCount = 0;
    int roomTotal = 16;
    int digCount = 2;
    public int startPosY;
    public int startPosX;
    public int storedPosY;
    public int storedPosX;
    public int[,] mapData = //Creates an array of digits between 0 to 2. 0's represent borders, 1 represents possible paths and 2 represents possible rooms.
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
    public void GenerateMap() //Generates a map using multiple methods.
    {
        GeneratePaths(pathCount, maxPaths); //Runs a chance of 5 over 9 for each 1, seeing if they become a path. Restricts paths to a maximum of 15. If a 1 becomes a path, it changes to 3 on the array.
        CheckNeighbours(2, 3, 0); //Checks in a plus around the room (2 on the array), if there are no paths next to the room, the room is deleted and 
        CheckNeighboursNumber(3, 2, 0, 1); 
        GenerateRooms();
        Console.Write(roomTotal);
    }
    public void PrintMap(int playerY, int playerX) //Prints the map using a different array based off the original map array. Also paints character where it is.
    {
        // string[] emojiMap = { "  ", "  ", " O", " +", "🈵", "🈳", "🈹", "🈯", "✴️", "⚜️" };
        // string[] emojiMap = { "  ", "  ", "🈵", "🈳", "➕", "🈹", "🈯", "✴️", "⚜️" };
        string[] emojiMap = { "  ", " E", " O", " +", "  ", "()", "[]", " C", " T", " R" };
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
    // void BorderCorrection(int playerX, int playerY)
    // {
    //     if (playerX > 7)
    //     {
    //         playerX = 7;
    //     }
    //     else if (playerX < 1)
    //     {
    //         playerX = 1;
    //     }
    //     if (playerY > 7)
    //     {
    //         playerY = 7;
    //     }
    //     else if (playerY < 1)
    //     {
    //         playerY = 1;
    //     }
    // }
    public bool IsOnPath(int playerX, int playerY, int movementX, int movementY)
    {
        if (mapData[playerY + movementY, playerX + movementX] >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MakePath(string direction, int playerX, int playerY) //Used to create a path in a direction to allow travel between closed paths.
    {
        if (digCount > 0)
        {
            if (direction == "Left")
            {
                if (playerX >= 1)
                {
                    if (mapData[playerY, playerX - 1] != 3 && mapData[playerY, playerX - 2] > 3)
                    {
                        mapData[playerY, playerX - 1] = 3;
                        digCount--;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "Right")
            {
                if (playerX <= 7)
                {
                    if (mapData[playerY, playerX + 1] != 3 && mapData[playerY, playerX + 2] > 3)
                    {
                        mapData[playerY, playerX + 1] = 3;
                        digCount--;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "Up")
            {
                if (playerY >= 1)
                {
                    if (mapData[playerY - 1, playerX] != 3 && mapData[playerY - 2, playerX] > 3)
                    {
                        mapData[playerY - 1, playerX] = 3;
                        digCount--;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
            else if (direction == "Down")
            {
                if (playerX <= 7)
                {
                    if (mapData[playerY + 1, playerX] != 3 && mapData[playerY + 2, playerX] > 3)
                    {
                        mapData[playerY + 1, playerX] = 3;
                        digCount--;
                    }
                    else
                    {
                        Console.WriteLine("Digging failed!");
                    }
                }
            }
        }

    }
    void GeneratePaths(int pathCount, int maxPaths) //Randomly generates paths for every 1 on the array, with a maximum of paths allowed. If a path is not generated, the 1 becomes a 0 
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
    void CheckNeighbours(int checkData, int neighbourData, int newData) //Checks the neighbours of a room square to see if it has any paths around it. If it does not, it makes itself 0
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
                        roomTotal--;
                    }
                }
            }
        }
    }
    void CheckNeighboursNumber(int checkData, int neighbourData, int newData, int countReq) //Checks the neighbours of a path to see if it has more than 1 rooom next to it. If it does not, it makes itself 0
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
    void GenerateRooms() // Generates rooms for all squares with a 2, prioritizing making a ascend room (5), while also having a pity system to ensure that a descend room (6) is generated. For the rest, randomly chooses between 3 different room types.
    {
        int ladderRoomChance = roomTotal;
        bool hasEscape = false;
        bool hasLadder = false;
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == 2 && !hasEscape) //Creats a ascend room
                {
                    mapData[y, x] = 5;
                    hasEscape = true;
                    startPosY = y;
                    startPosX = x;
                    ladderRoomChance--;
                }
                if (mapData[y, x] == 2 && Random.Shared.Next(1, ladderRoomChance) == 1 && !hasLadder) // Creates a descend room
                {
                    mapData[y, x] = 6;
                    hasLadder = true;
                }
                else if (mapData[y, x] == 2)
                {
                    int roomChance = Random.Shared.Next(1, 4);
                    if (roomChance == 1) // Creates a combat room
                    {
                        mapData[y, x] = 7;
                        ladderRoomChance--;

                    }
                    else if (roomChance == 2) //Creates a treasure room
                    {
                        mapData[y, x] = 8;
                        ladderRoomChance--;
                    }
                    else if (roomChance == 3) //Creates a rest room
                    {
                        mapData[y, x] = 9;
                        ladderRoomChance--;
                    }
                }
            }
        }
    }

    
    void Combat()
    {

    }
    void Treasure()
    {

    }
    void Rest()
    {

    }
}
