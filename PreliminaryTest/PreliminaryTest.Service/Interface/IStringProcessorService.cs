using System;
using System.Collections.Generic;

namespace PreliminaryTest.Service.Interface
{
    public interface IStringProcessorService
    {
        /// <summary>
        /// Get default string to return in case of null or empty string
        /// </summary>
        string DefaultString { get; set; }

        /// <summary>
        /// Subsrings pairs old and new values to replace in current string
        /// </summary>
        IEnumerable<Tuple<string, string>> CharsToReplace { get; set; }

        /// <summary>
        /// Max length of output string
        /// </summary>
        int MaxLength { get; set; }

        /// <summary>
        /// Process a collection of string values
        /// </summary>
        /// <param name="stringsToProcess">List of strings</param>
        /// <returns></returns>
        IList<string> ProcessStrings(IEnumerable<string> stringsToProcess);

        /// <summary>
        /// Process a collection of string values
        /// </summary>
        /// <param name="stringsToProcess">Comma-separated list of strings</param>
        /// <returns></returns>
        IList<string> ProcessStrings(params string[] stringsToProcess);
    }
}
