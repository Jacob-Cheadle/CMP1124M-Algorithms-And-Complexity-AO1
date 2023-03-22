namespace CMP1124M_A_C_AO1
{
    public class Testing
    {
        public Testing()
        {
            //Functionality 1 - Importing the File Paths
            string ROAD_1_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_1_256.txt";
            string ROAD_2_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_2_256.txt";
            string ROAD_3_256_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_3_256.txt";
            string ROAD_1_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_1_2048.txt";
            string ROAD_2_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_2_2048.txt";
            string ROAD_3_2048_path = @"C:\Users\jacob\OneDrive - University of Lincoln\Desktop\Algorithms & Complexity ASSIGNMENT\Road_3_2048.txt";

            //Functionality 1 - Converting the Files Imported Into Arrays
            int[] ROAD_1_256 = FileToArray(ROAD_1_256_path);
            int[] ROAD_2_256 = FileToArray(ROAD_2_256_path);
            int[] ROAD_3_256 = FileToArray(ROAD_3_256_path);
            int[] ROAD_1_2048 = FileToArray(ROAD_1_2048_path);
            int[] ROAD_2_2048 = FileToArray(ROAD_2_2048_path);
            int[] ROAD_3_2048 = FileToArray(ROAD_3_2048_path);

            //Functionality2(ROAD_1_256, ROAD_2_256, ROAD_3_256);
            //Functionality3(Sorts.BubbleSortAscending(ROAD_1_256), 2000);
            //Functionality4 IMPLEMENTED during functionality3
            Functionality5(ROAD_1_2048, ROAD_2_2048, ROAD_3_2048);



            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static void Functionality2(int[] list1, int[] list2, int[] list3)
        {
            Console.WriteLine("ROAD_1_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list1), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list1), 10);

            Console.WriteLine("ROAD_2_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list2), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list2), 10);

            Console.WriteLine("ROAD_3_256:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list3), 10);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list3), 10);
        }

        public static void Functionality3(int[] list, int key)
        {
            if (Search.LinearSearch(list, key, false).Length > 0)
            {
                PrintList(Search.LinearSearch(list, key, true), 1);
                return;
            }
            Console.WriteLine("Error: No Value Found");
        }

        public static void Functionality5(int[] list1, int[] list2, int[] list3)
        {
            Console.WriteLine("ROAD_1_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list1), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list1), 50);

            Console.WriteLine("ROAD_2_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list2), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list2), 50);

            Console.WriteLine("ROAD_3_2048:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.BubbleSortAscending(list3), 50);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.BubbleSortDescending(list3), 50);
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
        }

        public static void PrintList(int[] list, int increment)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (i % increment == 0)
                { Console.WriteLine($"{list[i]}"); }
            }
            Console.WriteLine();
        }

        public static int[] MergeRoads(int[] list1, int[] list2)
        {
            return list1.Concat(list2).ToArray();
        }
    }
}
