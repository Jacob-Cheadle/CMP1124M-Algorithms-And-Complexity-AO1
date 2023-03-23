namespace CMP1124M_A_C_AO1
{
    internal class Sorts
    {
        //Function to run the Ascending Bubble Sort
        public static int[] BubbleSortAscending(int[] list)
        {
            var n = list.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++) //loops through the array a minimum of once making n comparisons
                    if (list[j] > list[j + 1])
                    {
                        var tempVar = list[j];
                        list[j] = list[j + 1]; //compares 2 values, if one is bigger than the one infornt, they are swapped
                        list[j + 1] = tempVar;
                    }
            return list;
        }

        public static int[] BubbleSortDescending(int[] list) //same as ascending but with the for loop flipped so the values are set to the end of the array not the start
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

        public static int[] InsertionSortAscending(int[] list) //Ascending insertion sort
        {
            int length = list.Length;
            for (int i = 1; i < length; i++)
            {
                var key = list[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;) //runs through the array and finds a value, it then INSERTS the value in the correct position
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

        public static int[] InsertionSortDescending(int[] list) //Same as ascending but again flipped values in the for loop
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

        public static int[] RadixSortAscending(int[] list) //radix sort works by sorting each digit from least significant digit to most significant digit
        {
            int size = list.Length;
            var maxVal = GetMaxVal(list);
            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10) //exponent is our number we use to find significant digits
                CountingSort(list, size, exponent);

            int[] CountingSort(int[] list, int size, int exponent) //internal function to sort the values
            {
                var output = new int[size];
                var occurences = new int[10];
                for (int i = 0; i < 10; i++) //runs through different conditions to find occurences of values in certain positions
                { occurences[i] = 0; }
                for (int i = 0; i < size; i++)
                { occurences[(list[i] / exponent) % 10]++; }
                for (int i = 1; i < 10; i++)
                { occurences[i] += occurences[i - 1]; }
                for (int i = size - 1; i >= 0; i--)
                {
                    output[occurences[(list[i] / exponent) % 10] - 1] = list[i]; //copies the values in the set positions in occurences across from the list into output
                    occurences[(list[i] / exponent) % 10]--;
                }
                for (int i = 0; i < size; i++)
                    list[i] = output[i];
                return list;
            }

            int GetMaxVal(int[] list) //finds the largest value in the array
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

        public static int[] RadixSortDescending(int[] list) //similar to before however there is a function that has been made to reverse the array that is used at the end of the sort
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

        public static int[] QuickSortAscending(int[] list) //the array is divided into smaller groups around a PIVOT and then recombined once ordered, in a similar fashion to merge sort
        {
            int leftIndex = 0; //setup for the main algorithm as it is run recursively and needs some initial values
            int rightIndex = list.Length - 1;
            QuickSortAlgo(list, leftIndex, rightIndex);
            return list;

            int[] QuickSortAlgo(int[] list, int leftIndex, int rightIndex) //main recursive function for the quick sort
            {
                var i = leftIndex; //declares our limits and our pivot
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
                    if (i <= j) //as long as the left and right indexes haven't crossed over eachother then we continue adding the values back to list
                    {
                        int temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                        i++; //moves the edges further to continue the search
                        j--;
                    }
                }
                if (leftIndex < j) //if the algorithm hasn't reached the edges of the array then it runs again to seperate the remaining values
                    QuickSortAlgo(list, leftIndex, j);
                if (i < rightIndex)
                    QuickSortAlgo(list, i, rightIndex);
                return list;
            }
        }

        public static int[] QuickSortDescending(int[] list) //same as ascending but with a reverse function implemented
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

        public static int[] ReverseArray(int[] list) //reverses any given array
        {
            int[] reverseList = new int[list.Length];
            for (int i = 0; i < list.Length; i++) //loops through the whole length of the array assigning the end of one array to the start of another
            {
                reverseList[i] = list[list.Length - i];
            }
            return reverseList;
        }
    }
}
