namespace CMP1124M_A_C_AO1
{
    public class Search
    {
        public static int[] BinarySearch(int[] list, int key) //finds the centre and checks if the value is larger or smaller then keeps splitting the array until the value is found
        {
            List<int> allValues = new List<int>();
            int minNum = 0;
            int maxNum = list.Length - 1;

            while (minNum <= maxNum) //checking that the mid point hasnt been reached
            {
                int mid = (minNum + maxNum) / 2; //sets a new midpoint
                if (key == list[mid])
                {
                    allValues.Add(++mid); //adds teh position to the list if it has been found
                    for (int i = 0; i <= list.Length - mid - 1; i++) //loops through the values to either side of the mid point and adds all the matching ones to the list too
                    {
                        if (list[mid + i] == key)
                        { allValues.Add(++mid + i); }
                        else if (list[mid - i] == key)
                        { allValues.Add(++mid - i); }
                    }
                    return allValues.ToArray();
                }
                else if (key < list[mid]) //changes the max and min values and repeats
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

        public static int[] LinearSearch(int[] list, int key, bool writing) //searches through the whole list checking each value individually
        {
            bool Flag = false; //flag used to check if the value was found or not
            int closestNum = 0;
            var matching = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == key)
                { matching.Add(i); } //runs through and adds all matching values to a list if found
            }

            if (matching.Count == 0) //if no matching values were found then it finds the closest values
                Flag = true;
            {
                int UpperBound = key + 1;
                int LowerBound = key - 1; //sets bounds of where to search for the value, since the array is ordered we can spread out from the centre looking for values close
                while (matching.Count == 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i] == UpperBound || list[i] == LowerBound) //checks if the value has been found
                        {
                            matching.Add(i); //adds the value to the list
                            closestNum = list[i]; //sets the closestNum integer a value to compare
                        }
                    }
                    if (UpperBound < list.Length) { UpperBound++; }
                    if (LowerBound > 0) { LowerBound--; } //changes the bounds if no values have been found yet
                }
            }
            if (Flag && writing) //declares the closest values if the bool option of displaying them is true
            {
                Console.WriteLine("No Matching Values Found");
                Console.WriteLine($"Closest Value ({closestNum}) Found at postitions:");
            }
            return matching.ToArray(); //coverts the output to an array
        }
    }
}
