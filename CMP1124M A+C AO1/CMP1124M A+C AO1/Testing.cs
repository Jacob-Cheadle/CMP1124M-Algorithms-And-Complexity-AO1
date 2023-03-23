namespace CMP1124M_A_C_AO1
{
    public class Testing
    {
        public Testing()
        {
            while (true)
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

                Console.WriteLine();
                Console.WriteLine("Pick a functionality: ");
                Console.WriteLine("a) Functionality 1 - Read Files to Arrays");
                Console.WriteLine("b) Functionality 2 - Display Ascending and Descending Roads (256)");
                Console.WriteLine("c) Functionality 3 & 4 - Search Array for a value (displays closest value if not found)");
                Console.WriteLine("d) Functionality 5 - Repeat functionalities 2 & 4 with Roads (2048)");
                Console.WriteLine("e) Functionality 6 - Repeat functionalities 2 & 4 with Merged Roads (256)");
                Console.WriteLine("f) Functionality 7 - Repeat functionalities 2 & 4 with Merged Roads (2048)");
                Console.WriteLine();
                string answer = Console.ReadLine();
                answer = answer.ToUpper();
                switch (answer)
                {
                    case "A":
                        Console.WriteLine("Already Complete!");
                        break;
                    case "B":
                        Functionality2(ROAD_1_256, ROAD_2_256, ROAD_3_256);
                        break;
                    case "C":
                        Console.Write("Pick a value to search for: ");
                        int value = Convert.ToInt16(Console.ReadLine());
                        Functionality3(Sorts.BubbleSortAscending(ROAD_1_256), value);
                        break;
                    case "D":
                        Functionality5(ROAD_1_2048, ROAD_2_2048, ROAD_3_2048);
                        break;
                    case "E":
                        Functionality6(ROAD_1_256, ROAD_3_256, 10);
                        break;
                    case "F":
                        Functionality6(ROAD_1_2048, ROAD_3_2048, 50);
                        break;
                    default:
                        Console.WriteLine("Please Enter A Valid Option!");
                        break;
                }

            }
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

            Console.Write("Pick a value to search for in ROAD_3_2048: ");
            int key = Convert.ToInt16(Console.ReadLine());
            list3 = Sorts.RadixSortAscending(list3);
            PrintList(Search.LinearSearch(list3, key, true), 1);
        }

        public static void Functionality6(int[] list1, int[] list2, int increment)
        {
            int[] NEW_ROAD = MergeRoads(list1, list2);
            Console.WriteLine("NEW ROAD:");
            Console.WriteLine("ASCENDING:");
            PrintList(Sorts.QuickSortAscending(NEW_ROAD), increment);
            Console.WriteLine("DESCENDING:");
            PrintList(Sorts.InsertionSortDescending(NEW_ROAD), increment);

            Console.Write("Pick a value to search for: ");
            int key = Convert.ToInt16(Console.ReadLine());
            NEW_ROAD = Sorts.RadixSortAscending(NEW_ROAD);
            PrintList(Search.LinearSearch(NEW_ROAD, key, true), 1);
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
