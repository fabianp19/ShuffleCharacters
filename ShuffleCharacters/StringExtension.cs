using System;
using System.Text;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentNullException">Source string is null.</exception>
        /// <exception cref="ArgumentException">Source string is empty or a white space.</exception>
        /// <exception cref="ArgumentException">Count of iterations is less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            Validate(source, count);

            StringBuilder temp1 = new StringBuilder();
            StringBuilder temp2 = new StringBuilder();
            temp1.Append(source);

            int a = 1;
            for (int i = 0; i < count; i++)
            {
                temp2.Clear();
                temp2.Append(temp1[0]);

                for (int j = 2; j < source?.Length; j += 2)
                {
                    temp2.Append(temp1[j]);
                }

                for (int j = 1; j < source?.Length; j += 2)
                {
                    temp2.Append(temp1[j]);
                }

                if (temp2.Equals(source))
                {
                    count = (count % a) + i + 1;
                }

                temp1.Clear();
                temp1.Append(temp2);
                a++;
            }

            return temp1.ToString();
        }

        private static void Validate(string source, int count)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source is empty", nameof(source));
            }

            if (count < 0)
            {
                throw new ArgumentException("Count is less than 0", nameof(count));
            }
        }
    }
}