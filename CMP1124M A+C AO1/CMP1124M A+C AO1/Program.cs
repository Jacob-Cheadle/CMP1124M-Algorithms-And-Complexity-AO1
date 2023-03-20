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

            PrintList(InsertionSortDescending(ROAD_1_256));

            //TestFileAscending(ROAD_1_256);
            //TestFileAscending(ROAD_2_256);
            //TestFileAscending(ROAD_3_256);
            //TestFileAscending(ROAD_1_2048);
            //TestFileAscending(ROAD_2_2048);
            //TestFileAscending(ROAD_3_2048);

            //TestFileDescending(ROAD_1_256);
            //TestFileDescending(ROAD_2_256);
            //TestFileDescending(ROAD_3_256);
            //TestFileDescending(ROAD_1_2048);
            //TestFileDescending(ROAD_2_2048);
            //TestFileDescending(ROAD_3_2048);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static void TestFileAscending(int[] FileArray)
        {
            if (BubbleSortAscending(FileArray) == QuickSortAscending(FileArray)
                & QuickSortAscending(FileArray) == RadixSortAscending(FileArray)
                & RadixSortAscending(FileArray) == InsertionSortAscending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        }

        public static void TestFileDescending(int[] FileArray)
        {
            if (BubbleSortDescending(FileArray) == QuickSortDescending(FileArray)
                & QuickSortDescending(FileArray) == RadixSortDescending(FileArray)
                & RadixSortDescending(FileArray) == InsertionSortDescending(FileArray))
            { Console.WriteLine("SUCCESS!"); }
        } //NEED TO COMPLETE DESCENDING FUNCTIONS FIRST

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

        public static int[] BubbleSortAscending(int[] list)
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

        public static int[] BubbleSortDescending(int[] list)
        {
            var n = list.Length;
            for (int i = n - 2; i >= 0; i--)
                for (int j = n - i - 2; j >= 0; j--)
                    if (list[j] < list[j + 1])
                    {
                        var tempVar = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tempVar;
                    }
            return list;
        }

        public static int[] InsertionSortAscending(int[] list)
        {
            int length = list.Length;
            for (int i = 1; i < length; i++)
            {
                var key = list[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < list[j])
                    {
                        list[j + 1] = list[j];
                        j--;
                        list[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            return list;
        }

        public static int[] InsertionSortDescending(int[] list)
        {
            int length = list.Length;
            for (int i = 1; i < length; i++)
            {
                var key = list[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key > list[j])
                    {
                        list[j + 1] = list[j];
                        j--;
                        list[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            return list;
        } //NOT COMPLETE

        public static int[] RadixSortAscending(int[] list)
        {
            int size = list.Length;
            var maxVal = GetMaxVal(list);
            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(list, size, exponent);

            int[] CountingSort(int[] list, int size, int exponent)
            {
                var output = new int[size];
                var occurences = new int[10];
                for (int i = 0; i < 10; i++)
                    occurences[i] = 0;
                for (int i = 0; i < size; i++)
                    occurences[(list[i] / exponent) % 10]++;
                for (int i = 1; i < 10; i++)
                    occurences[i] += occurences[i - 1];
                for (int i = size - 1; i >= 0; i--)
                {
                    output[occurences[(list[i] / exponent) % 10] - 1] = list[i];
                    occurences[(list[i] / exponent) % 10]--;
                }
                for (int i = 0; i < size; i++)
                    list[i] = output[i];
                return list;
            }

            int GetMaxVal(int[] list)
            {
                int size = list.Length;
                var maxVal = list[0];
                for (int i = 1; i < size; i++)
                    if (list[i] > maxVal)
                        maxVal = list[i];
                return maxVal;
            }

            return list;
        }

        public static int[] RadixSortDescending(int[] list)
        {
            int size = list.Length;
            var maxVal = GetMaxVal(list);
            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(list, size, exponent);

            int[] CountingSort(int[] list, int size, int exponent)
            {
                var output = new int[size];
                var occurences = new int[10];
                for (int i = 0; i < 10; i++)
                    occurences[i] = 0;
                for (int i = 0; i < size; i++)
                    occurences[(list[i] / exponent) % 10]++;
                for (int i = 1; i < 10; i++)
                    occurences[i] += occurences[i - 1];
                for (int i = size - 1; i >= 0; i--)
                {
                    output[occurences[(list[i] / exponent) % 10] - 1] = list[i];
                    occurences[(list[i] / exponent) % 10]--;
                }
                for (int i = 0; i < size; i++)
                    list[i] = output[i];
                return list;
            }

            int GetMaxVal(int[] list)
            {
                int size = list.Length;
                var maxVal = list[0];
                for (int i = 1; i < size; i++)
                    if (list[i] > maxVal)
                        maxVal = list[i];
                return maxVal;
            }

            return list;
        } //NOT COMPLETE

        public static int[] QuickSortAscending(int[] list)
        {
            int leftIndex = 0;
            int rightIndex = list.Length - 1;
            QuickSortAlgo(list, leftIndex, rightIndex);
            return list;

            int[] QuickSortAlgo(int[] list, int leftIndex, int rightIndex)
            {
                var i = leftIndex;
                var j = rightIndex;
                var pivot = list[leftIndex];
                while (i <= j)
                {
                    while (list[i] < pivot)
                    { i++; }
                    while (list[j] > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                        i++;
                        j--;
                    }
                }
                if (leftIndex < j)
                    QuickSortAlgo(list, leftIndex, j);
                if (i < rightIndex)
                    QuickSortAlgo(list, i, rightIndex);
                return list;
            }
        }

        public static int[] QuickSortDescending(int[] list)
        {
            int leftIndex = 0;
            int rightIndex = list.Length - 1;
            QuickSortAlgo(list, leftIndex, rightIndex);
            return list;

            int[] QuickSortAlgo(int[] list, int leftIndex, int rightIndex)
            {
                var i = leftIndex;
                var j = rightIndex;
                var pivot = list[leftIndex];
                while (i <= j)
                {
                    while (list[i] < pivot)
                    { i++; }
                    while (list[j] > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                        i++;
                        j--;
                    }
                }
                if (leftIndex < j)
                    QuickSortAlgo(list, leftIndex, j);
                if (i < rightIndex)
                    QuickSortAlgo(list, i, rightIndex);
                return list;
            }
        } //NOT COMPLETE
    }
}

