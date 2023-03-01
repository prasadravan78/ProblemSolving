namespace _060SortArray
{
    /*
    Given an array of integers nums, sort the array in ascending order and return it.

    You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.

 

    Example 1:

    Input: nums = [5,2,3,1]
    Output: [1,2,3,5]
    Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).
    Example 2:

    Input: nums = [5,1,1,2,0,0]
    Output: [0,0,1,1,2,5]
    Explanation: Note that the values of nums are not necessairly unique. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 3, 6, 2, 9, 8 };

            SortArray(array);

            foreach (var num in array)
            {
                Console.Write(num + " ");
            }

            Console.ReadLine();
        }

        public static int[] SortArray(int[] array)
        {
            Sort(array, 0, array.Length - 1);

            return array;
        }

        private static void Sort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var mid = (start + end) / 2;

            Sort(array, start, mid);
            Sort(array, mid + 1, end);

            Merge(array, start, mid, end);
        }

        private static void Merge(int[] array, int start, int mid, int end)
        {
            int i = 0, j = 0, k = start;
            var array1Size = mid - start + 1;
            var array2Size = end - mid;

            var auxArray1 = new int[array1Size];
            var auxArray2 = new int[array2Size];

            Array.Copy(array, start, auxArray1, 0, array1Size);
            Array.Copy(array, mid + 1, auxArray2, 0, array2Size);

            while (i < array1Size && j < array2Size)
            {
                if (auxArray1[i] < auxArray2[j])
                {
                    array[k] = auxArray1[i];
                    i++;
                }
                else
                {
                    array[k] = auxArray2[j];
                    j++;
                }

                k++;
            }

            while (i < array1Size)
            {
                array[k] = auxArray1[i];
                i++;
                k++;
            }

            while (j < array2Size)
            {
                array[k] = auxArray2[j];
                j++;
                k++;
            }
        }
    }
}