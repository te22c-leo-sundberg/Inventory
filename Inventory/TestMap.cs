class TestMap
{
    public int[,] mapData =
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 3, 0, 3, 0, 3, 0, 3, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 3, 0, 3, 0, 3, 0, 3, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 3, 0, 3, 0, 3, 0, 3, 0 },
        { 0, 2, 1, 2, 1, 2, 1, 2, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };

    public void GenerateMap()
    {
        int maxPaths = 15;
        int pathCount = 0;
        for (int y = 0; y < mapData.GetLength(0); y++) //
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == 1 || mapData[y, x] == 3)
                {
                    int pathChance = Random.Shared.Next(1, 10);
                    if (pathChance > 4 && pathCount <= maxPaths)
                    {
                        pathCount++;
                        if (mapData[y, x] == 1)
                        {
                            mapData[y, x] = 5;
                        }
                        else
                        {
                            mapData[y, x] = 4;
                        }
                    }
                }
            }
        }
        CheckNeighbours(2, 3, 0);
        CheckNeighboursNumber(3, 2, 0, 1);
    }

    public void PrintMap()
    {
        string[] emojiMap = { "  ", "  ", "🈵", "🈳", "↕️", "↔️", "➕", "🈹", "🈯", "✴️", "⚜️" };
        // string[] emojiMap = { "  ", "  ", "🈵", "🈳", "➕", "🈹", "🈯", "✴️", "⚜️" };
        // string[] emojiMap = { "  ", "  ", " O", " +" };

        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                string visualMap = emojiMap[mapData[y, x]];
                Console.Write(visualMap);
            }
            Console.WriteLine();
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
                        && mapData[y - 1, x - 1] != neighbourData
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
        int count = 0;
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                if (mapData[y, x] == checkData)
                {
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