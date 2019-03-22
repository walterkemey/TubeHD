using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStreamAPI.Helpers
{
    public static class ArraySliceExtension
    {
        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }

        public static T[] Slice<T>(this T[] source, int value)
        {
            // Return new array.
            T[] res = new T[source.Length - 1];
            if (value < 0)
            {
                value = source.Length - value;

                int i2 = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (i != value) // value = position.
                    {
                        res[i2] = source[i2];
                        i2++;
                    }
                }
            }
            else
            {
                int i2 = 0;
                for (int i = 0; i < source.Length; i++)
                {
                    if (i != value) // value = position.
                    {
                        res[i2] = source[i2];
                        i2++;
                    }
                }
            }
            return res;
        }
    }
}
