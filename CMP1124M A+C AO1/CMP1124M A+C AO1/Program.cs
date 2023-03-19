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
            //PrintList(BubbleSort(ROAD_1_256));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_1_256));

            Console.WriteLine("ROAD_2_256");
            //PrintList(BubbleSort(ROAD_2_256));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_2_256));

            Console.WriteLine("ROAD_3_256");
            //PrintList(BubbleSort(ROAD_3_256));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_3_256));

            Console.WriteLine("ROAD_1_2048");
            //PrintList(BubbleSort(ROAD_1_2048));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_1_2048));

            Console.WriteLine("ROAD_2_2048");
            //PrintList(BubbleSort(ROAD_2_2048));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_2_2048));

            Console.WriteLine("ROAD_3_2048");
            //PrintList(BubbleSort(ROAD_3_2048));
            //PrintList(QuickSortSetup(ROAD_1_256));
            PrintList(RadixSort(ROAD_3_2048));

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

        public static int[] InsertionSort(int[] list)
        {
            return list;
        }
        public static int[] RadixSort(int[] list)
        {
            int size = list.Length;
            var maxVal = GetMaxVal(list);
            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(list, size, exponent);
            return list;
        }
        public static int GetMaxVal(int[] list)
        {
            int size = list.Length;
            var maxVal = list[0];
            for (int i = 1; i < size; i++)
                if (list[i] > maxVal)
                    maxVal = list[i];
            return maxVal;
        }



        public static void CountingSort(int[] list, int size, int exponent)
        {
            var outputArr = new int[size];
            var occurences = new int[10];
            for (int i = 0; i < 10; i++)
                occurences[i] = 0;
            for (int i = 0; i < size; i++)
                occurences[(list[i] / exponent) % 10]++;
            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];
            for (int i = size - 1; i >= 0; i--)
            {
                outputArr[occurences[(list[i] / exponent) % 10] - 1] = list[i];
                occurences[(list[i] / exponent) % 10]--;
            }
            for (int i = 0; i < size; i++)
                list[i] = outputArr[i];
        }

        public static int[] QuickSortSetup(int[] list)
        {
            int leftIndex = 0;
            int rightIndex = list.Length - 1;
            QuickSort(list, leftIndex, rightIndex);
            return list;
        }

        public static int[] QuickSort(int[] list, int leftIndex, int rightIndex)
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
                QuickSort(list, leftIndex, j);
            if (i < rightIndex)
                QuickSort(list, i, rightIndex);
            return list;
        }

    }
}

