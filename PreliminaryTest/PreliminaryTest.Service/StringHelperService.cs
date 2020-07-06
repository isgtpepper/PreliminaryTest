using PreliminaryTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreliminaryTest.Service
{
    /// <summary>
    /// Common operations with strings
    /// </summary>
    public class StringHelperService : IStringHelperService
    {
        /// <summary>
        /// Replace subsrings of current string builder with a new substrings 
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="tuples">Char pairs to replace in current string builder</param>
        public void ReplaceCharacters(StringBuilder stringBuilder, params Tuple<string, string>[] tuples)
        {
            ReplaceCharacters(stringBuilder, tuples.ToList());
        }

        /// <summary>
        /// Replace subsrings of current string builder with a new substrings 
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="tuples">Char pairs to replace in current string builder</param>
        public void ReplaceCharacters(StringBuilder stringBuilder, IEnumerable<Tuple<string, string>> tuples) {

            if (tuples == null)
            {
                return;
            }

            tuples.ToList().ForEach(tuple => stringBuilder.Replace(tuple.Item1, tuple.Item2));
        }

        /// <summary>
        /// Reduce contiguous duplicate characters in the same case to a single character
        /// </summary>
        /// <param name="stringBuilder">stringBuilder</param>
        public void RemoveContiguousDuplicateCharacters(StringBuilder stringBuilder)
        {

            var charPosition = 1;

            while (charPosition < stringBuilder.Length)
            {

                if (stringBuilder[charPosition] == stringBuilder[charPosition - 1])
                {

                    stringBuilder.Remove(charPosition, 1);
                    continue;
                }

                charPosition++;
            }
        }

        /// <summary>
        /// Truncate string to max length
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="maxLength">max returned lenght</param>
        public void TruncateString(StringBuilder stringBuilder, int maxLength)
        {
            if (stringBuilder.Length <= maxLength) {
                return;
            }

            var itemsToRemoveLength = stringBuilder.Length - maxLength;
            stringBuilder.Remove(maxLength, itemsToRemoveLength);
        }
    }
}
