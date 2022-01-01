using System;

#pragma warning disable S2368

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Sort order types.
        /// </summary>
        public enum OrderBy
        {
            /// <summary>
            /// Represents an ascending by sum sort.
            /// </summary>
            AscendingBySum,

            /// <summary>
            /// Represents a descending by sum sort.
            /// </summary>
            DescendingBySum,

            /// <summary>
            /// Represents an ascending by max value sort.
            /// </summary>
            AscendingByMax,

            /// <summary>
            /// Represents a descending by max value sort.
            /// </summary>
            DescendingByMax,
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            for (int i = 0; i < source.GetLength(0); i++)
            {
                if (source[i] == null)
                {
                    for (int j = i; j >= 1; j--)
                    {
                        source[j] = source[j - 1];
                    }

                    source[0] = null;
                }
            }

            source.BubbleSort(OrderBy.AscendingBySum);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            for (int i = source.GetLength(0) - 1; i >= 0; i--)
            {
                if (source[i] == null)
                {
                    for (int j = i; j < source.GetLength(0) - 1; j++)
                    {
                        source[j] = source[j + 1];
                    }

                    source[source.GetLength(0) - 1] = null;
                }
            }

            source.BubbleSort(OrderBy.DescendingBySum);
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            for (int i = 0; i < source.GetLength(0); i++)
            {
                if (source[i] == null)
                {
                    for (int j = i; j >= 1; j--)
                    {
                        source[j] = source[j - 1];
                    }

                    source[0] = null;
                }
            }

            source.BubbleSort(OrderBy.AscendingByMax);
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            for (int i = source.GetLength(0) - 1; i >= 0; i--)
            {
                if (source[i] == null)
                {
                    for (int j = i; j < source.GetLength(0) - 1; j++)
                    {
                        source[j] = source[j + 1];
                    }

                    source[source.GetLength(0) - 1] = null;
                }
            }

            source.BubbleSort(OrderBy.DescendingByMax);
        }

        private static int SumOfArray(int[] source)
        {
            int sum = 0;
            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        private static int FindMax(int[] source)
        {
            int max = source[0];
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                }
            }

            return max;
        }

        private static void BubbleSort(this int[][] source, OrderBy order)
        {
            for (int i = 0; i < source.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < source.GetLength(0) - i - 1; j++)
                {
                    if (source[j] == null || source[j + 1] == null)
                    {
                        continue;
                    }
                   
                    if ((order == OrderBy.AscendingBySum && SumOfArray(source[j]) > SumOfArray(source[j + 1])) ||
                        (order == OrderBy.DescendingBySum && SumOfArray(source[j]) < SumOfArray(source[j + 1])) ||
                        (order == OrderBy.AscendingByMax && FindMax(source[j]) > FindMax(source[j + 1])) ||
                        (order == OrderBy.DescendingByMax && FindMax(source[j]) < FindMax(source[j + 1])))
                    {
                        int[] tmp = source[j];
                        source[j] = source[j + 1];
                        source[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
