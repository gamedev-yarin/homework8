using System;

namespace TestCaveGenerator
{

    class Program
    {

        static int gridSize = 10;

        static void print(int[,] data)
        {
            for (int x = 0; x < gridSize; ++x)
            {
                for (int y = 0; y < gridSize; ++y)
                {
                    Console.Write(data[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random random = new Random();

            CaveGenerator caveGenerator = new CaveGenerator(0.3f, 10);
            caveGenerator.RandomizeMap();
            for (int i = 0; i < 10; ++i)
            {
                print(caveGenerator.GetMap());
                Console.ReadKey();
                caveGenerator.SmoothMap();
            }

            Console.WriteLine("End CaveGenerator Test");
            
        }
    }
}
