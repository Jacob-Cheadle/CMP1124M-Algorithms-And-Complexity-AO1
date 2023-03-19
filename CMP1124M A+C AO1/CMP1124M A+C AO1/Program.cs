namespace SortingProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            string ROAD_1_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_1_256.txt";
            string ROAD_2_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_2_256.txt";
            string ROAD_3_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_3_256.txt";
            string ROAD_1_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_1_2048.txt";
            string ROAD_2_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_2_2048.txt";
            string ROAD_3_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_3_2048.txt";

            int[] ROAD_1_256 = FileToArray(ROAD_1_256_path);
            int[] ROAD_2_256 = FileToArray(ROAD_2_256_path);
            int[] ROAD_3_256 = FileToArray(ROAD_3_256_path);
            int[] ROAD_1_2048 = FileToArray(ROAD_1_2048_path);
            int[] ROAD_2_2048 = FileToArray(ROAD_2_2048_path);
            int[] ROAD_3_2048 = FileToArray(ROAD_3_2048_path);

            Console.WriteLine("ROAD_1_256");
            PrintList(BubbleSort(ROAD_1_256));

            Console.WriteLine("ROAD_2_256");
            PrintList(BubbleSort(ROAD_2_256));

            Console.WriteLine("ROAD_3_256");
            PrintList(BubbleSort(ROAD_3_256));

            Console.WriteLine("ROAD_1_2048");
            PrintList(BubbleSort(ROAD_1_2048));

            Console.WriteLine("ROAD_2_2048");
            PrintList(BubbleSort(ROAD_2_2048));

            Console.WriteLine("ROAD_3_2048");
            PrintList(BubbleSort(ROAD_3_2048));

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static int[] FileToArray(string filePath)
        {
            var list = new List<int>();
            var data = File.ReadAllLines(filePath);
            foreach (var s in data)
            {
                list.Add(Convert.ToInt32(s));
            }
            return list.ToArray();
        }

        public static void PrintList(int[] list)
        {
            Console.WriteLine();
            for (int i = 0; i < list.Length; i++)
            {
                if (i % 20 == 0 & i > 0)
                { Console.WriteLine($"{list[i]}"); }
                else { Console.Write($"{list[i]}, "); }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static int[] BubbleSort(int[] list)
        {
            var n = list.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (list[j] > list[j + 1])
                    {
                        var tempVar = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tempVar;
                    }
            return list;
        }

    }
}

