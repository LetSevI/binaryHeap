namespace BinaryHeapLib
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
