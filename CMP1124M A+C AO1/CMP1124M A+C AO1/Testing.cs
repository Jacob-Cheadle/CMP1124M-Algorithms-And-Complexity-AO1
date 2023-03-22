namespace CMP1124M_A_C_AO1
{
    public class Testing
    {
        public Testing()
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

            ROAD_1_256 = Sorts.BubbleSortAscending(ROAD_1_256);

            Console.WriteLine("BEFORE");
            PrintList(ROAD_1_256, 10);
            Console.WriteLine("AFTER");
            PrintList(Search.LinearSearch(ROAD_1_256, 11), 1);








            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static void Functionality2(int[] list)
        {
            PrintList(Sorts.BubbleSortAscending(list), 10);
            PrintList(Sorts.BubbleSortDescending(list), 10);

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

        public static void TestFileAscending(int[] FileArray)
        {
            if (Sorts.BubbleSortAscending(FileArray) == Sorts.QuickSortAscending(FileArray)
                & Sorts.QuickSortAscending(FileArray) == Sorts.RadixSortAscending(FileArray)
                & Sorts.RadixSortAscending(FileArray) == Sorts.InsertionSortAscending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        }

        public static void TestFileDescending(int[] FileArray)
        {
            if (Sorts.BubbleSortDescending(FileArray) == Sorts.QuickSortDescending(FileArray)
                & Sorts.QuickSortDescending(FileArray) == Sorts.RadixSortDescending(FileArray)
                & Sorts.RadixSortDescending(FileArray) == Sorts.InsertionSortDescending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        } //NEED TO COMPLETE DESCENDING FUNCTIONS FIRST

        public static void PrintList(int[] list, int increment)
        {
            Console.WriteLine();
            for (int i = 0; i < list.Length; i++)
            {
                if (i % increment == 0 & i > 0)
                { Console.WriteLine($"{list[i]}"); }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
