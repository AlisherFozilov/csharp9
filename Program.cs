using System;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("original array called 'a':");
            print(a);

            Console.WriteLine();
            Console.WriteLine("Slicing operations");
            Console.WriteLine("=======================================");

            Console.WriteLine("Slice(a, 1, 4)");
            print(ArrayHelper.Slice(a, 1, 4));

            Console.WriteLine("Slice(a, 1)");
            print(ArrayHelper.Slice(a, 1));

            Console.WriteLine("Slice(a, end: 4)");
            print(ArrayHelper.Slice(a, end: 4));

            Console.WriteLine("Slice(a, -2)");
            print(ArrayHelper.Slice(a, -2));

            Console.WriteLine("Slice(a, -10)");
            print(ArrayHelper.Slice(a, -10));

            Console.WriteLine("Slice(a, 2, -1)");
            print(ArrayHelper.Slice(a, 2, -1));
            
            Console.WriteLine("Slice(a, 2, -1000)");
            print(ArrayHelper.Slice(a, 2, -1000));
            
            Console.WriteLine("Slice(a, 2, 1)");
            print(ArrayHelper.Slice(a, 2, 1));
            
            Console.WriteLine("Slice(a, 2, 2)");
            print(ArrayHelper.Slice(a, 2, 2));
        }
        static void print<T>(T[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Empty array");
                return;
            }
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    static class ArrayHelper
    {
        static public T Pop<T>(ref T[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException();
            }
            var newSize = array.Length - 1;
            var newArray = new T[newSize];
            var lastElement = array[array.Length - 1];

            Array.Copy(array, newArray, newSize);
            array = newArray;
            return lastElement;
        }

        static public int Push<T>(ref T[] array, T elem)
        {
            var newSize = array.Length + 1;
            var newArray = new T[newSize];
            Array.Copy(array, newArray, array.Length);

            newArray[newSize - 1] = elem;
            array = newArray;
            return newSize;
        }

        static public T Shift<T>(ref T[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException();
            }
            var newSize = array.Length - 1;
            var newArray = new T[newSize];
            var firstElement = array[0];

            Array.Copy(array, 1, newArray, 0, newSize);
            array = newArray;
            return firstElement;
        }

        static public int UnShift<T>(ref T[] array, T elem)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException();
            }
            var newSize = array.Length + 1;
            var newArray = new T[newSize];

            newArray[0] = elem;
            Array.Copy(array, 0, newArray, 1, array.Length);
            array = newArray;
            return newSize;
        }

        static public T[] Slice<T>(T[] array, int begin = 0, int end = 0)
        {
            if (begin > array.Length)
            {
                return new T[] { };
            }

            if (end == 0)
            {
                end = array.Length;
            }

            if (begin < 0)
            {
                var newLength = -1 * begin;
                return Slice(array, array.Length - newLength);
            }

            if (end < 0)
            {
                return Slice(array, begin, array.Length + end);
            }

            if (end <= begin)
            {
                return new T[] { };
            }

            var length = end - begin;
            var sliced = new T[length];
            Array.Copy(array, begin, sliced, 0, length);
            return sliced;
        }
    }
}
