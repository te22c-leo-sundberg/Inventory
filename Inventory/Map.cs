class Map
{
    public int[,] mapData = {
{0,0,0,0,0,0,0,0,0},
{0,2,1,2,1,2,1,2,0},
{0,1,0,1,0,1,0,1,0},
{0,2,1,2,1,2,1,2,0},
{0,1,0,1,0,1,0,1,0},
{0,2,1,2,1,2,1,2,0},
{0,1,0,1,0,1,0,1,0},
{0,2,1,2,1,2,1,2,0},
{0,0,0,0,0,0,0,0,0},
};

    void GenerateMap()
    {
        mapData[1, 1] = 2;
        for (int y = -1; y < mapData.GetLength(0) - 1; y += 2)
        {
            for (int x = -1; x < mapData.GetLength(1) - 1; x += 2)
            {

            }
        }
    }
    public void PrintMap()
    {
        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)
            {
                Console.WriteLine(mapData[y,x]);
            }
        }
    }
    void CheckNeighbours(int y, int x)
    {

        int maxPaths = 15;
        int pathCount = 0;
        ChangeNeighbour(mapData[y + 1, x], pathCount, maxPaths, 1, 3);
        ChangeNeighbour(mapData[y - 1, x], pathCount, maxPaths, 1, 3);
        ChangeNeighbour(mapData[y, x + 1], pathCount, maxPaths, 1, 3);
        ChangeNeighbour(mapData[y, x - 1], pathCount, maxPaths, 1, 3);
    }
    void ChangeNeighbour(int array, int pathCount,int maxPaths, int currentTile, int newTile)
    {
        if (array == currentTile)
        {
            int success = Random.Shared.Next(1, 3);
            if (Random.Shared.Next(1, 4) < 1 && pathCount > maxPaths)
            {
                array = newTile;
                pathCount++;
            }
            else
            {

            }
        }
    }
}


