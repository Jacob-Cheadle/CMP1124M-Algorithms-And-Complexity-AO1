namespace CMP1124M_A_C_AO1
{
    public class Search
    {
        public static int[] BinarySearch(int[] list, int key)
        {
            List<int> allValues = new List<int>();
            int minNum = 0;
            int maxNum = list.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == list[mid])
                {
                    allValues.Add(++mid);
                    for (int i = 0; i <= list.Length - mid - 1; i++)
                    {
                        if (list[mid + i] == key)
                        { allValues.Add(++mid + i); }
                        else if (list[mid - i] == key)
                        { allValues.Add(++mid - i); }
                    }
                    return allValues.ToArray();
                }
                else if (key < list[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return null;

        }

        public static int[] LinearSearch(int[] list, int key)
        {
            List<int> allValues = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == key)
                {
                    allValues.Add(i);
                }
            }
            return allValues.ToArray();
        }
    }
}
