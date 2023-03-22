namespace CMP1124M_A_C_AO1
{
    internal class Sorts
    {
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
        }

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
            list = ReverseArray(list);
            return list;
        } 

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
                list = ReverseArray(list);
                return list;
            }
        } 

        public static int[] ReverseArray(int[] list)
        {
            int[] reverseList = new int[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                reverseList[i] = list[list.Length - i];
            }
            return reverseList;
        }
    }
}
