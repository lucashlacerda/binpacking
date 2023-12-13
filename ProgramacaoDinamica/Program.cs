using System;
using System.Collections.Generic;

class Container
{
    public int Width { get; }
    public int Length { get; }

    public Container(int width, int length)
    {
        Width = width;
        Length = length;
    }
}

class BinPacking
{
    static int MinShips(List<Container> containers, int shipWidth, int shipLength)
    {
        containers.Sort((a, b) => b.Length.CompareTo(a.Length)); // Ordena os containers por comprimento em ordem decrescente

        int nContainers = containers.Count;
        int nShips = 0;
        List<int> remainingWidth = new List<int> { shipWidth };
        List<int> remainingLength = new List<int> { shipLength };

        for (int i = 0; i < nContainers; i++)
        {
            bool placed = false;

            for (int j = 0; j <= nShips; j++)
            {
                if (containers[i].Width <= remainingWidth[j] && containers[i].Length <= remainingLength[j])
                {
                    remainingWidth[j] -= containers[i].Width;
                    remainingLength[j] -= containers[i].Length;
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                nShips++;
                remainingWidth.Add(shipWidth - containers[i].Width);
                remainingLength.Add(shipLength - containers[i].Length);
            }
        }

        return nShips;
    }

    static void Main()
    {
        List<Container> containers = new List<Container>
        {
            new Container(2, 3),
            new Container(1, 2),
            new Container(3, 4),
            new Container(2, 2),
            new Container(1, 1)
        };

        int shipWidth = 5;
        int shipLength = 5;

        int result = MinShips(containers, shipWidth, shipLength);
        Console.WriteLine($"Número mínimo de navios necessários: {result}");
        Console.ReadLine();
    }
}
