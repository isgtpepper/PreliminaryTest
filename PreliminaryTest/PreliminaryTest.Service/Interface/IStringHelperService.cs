using System;
using System.Collections.Generic;
using System.Text;

namespace PreliminaryTest.Service.Interface
{
    public interface IStringHelperService
    {
        /// <summary>
        /// Replace subsrings of current string builder with a new substrings 
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="tuples">Char pairs to replace in current string builder</param>
        void ReplaceCharacters(StringBuilder stringBuilder, params Tuple<string, string>[] tuples);

        /// <summary>
        /// Replace subsrings of current string builder with a new substrings 
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="tuples">Char pairs to replace in current string builder</param>
        void ReplaceCharacters(StringBuilder stringBuilder, IEnumerable<Tuple<string, string>> tuples);

        /// <summary>
        /// Reduce contiguous duplicate characters in the same case to a single character
        /// </summary>
        /// <param name="stringBuilder">stringBuilder</param>
        void RemoveContiguousDuplicateCharacters(StringBuilder stringBuilder);

        /// <summary>
        /// Truncate string to max length
        /// </summary>
        /// <param name="stringBuilder">StringBuilder</param>
        /// <param name="maxLength">max returned lenght</param>
        void TruncateString(StringBuilder stringBuilder, int maxLength);
    }
}
