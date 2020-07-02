using PreliminaryTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreliminaryTest.Service
{
    /// <summary>
    /// Process a collection of string values
    /// </summary>
    public class StringProcessorService : IStringProcessorService
    {
        private readonly IStringHelperService _stringHelperService;

        /// <summary>
        /// Get default string to return in case of null or empty string
        /// </summary>
        public string DefaultString { get; set; } = " ";

        /// <summary>
        /// Subsrings pairs old and new values to replace in current string
        /// </summary>
        public IEnumerable<Tuple<string, string>> CharsToReplace { get; set; } = new List<Tuple<string, string>>() {
            Tuple.Create("$", "£"),
            Tuple.Create("_", string.Empty),
            Tuple.Create("4", string.Empty)
        };

        /// <summary>
        /// Max length of output string
        /// </summary>
        public int MaxLength { get; set; } = 15;

        public StringProcessorService(IStringHelperService stringHelperService) {

            _stringHelperService = stringHelperService;
        }

        /// <summary>
        /// Process a collection of string values
        /// </summary>
        /// <param name="stringsToProcess">List of strings</param>
        /// <returns></returns>
        public IList<string> ProcessStrings(IEnumerable<string> stringsToProcess)
        {
            var resultList = new List<string>();

            if (stringsToProcess == null)
            {
                return resultList;
            }

            resultList = stringsToProcess.Select(stringToProcess => ProcessString(stringToProcess)).ToList();
            return resultList;
        }

        /// <summary>
        /// Process a collection of string values
        /// </summary>
        /// <param name="stringsToProcess">Comma-separated list of strings</param>
        /// <returns></returns>
        public IList<string> ProcessStrings(params string[] stringsToProcess)
        {
            return ProcessStrings(stringsToProcess.ToList());
        }

        /// <summary>
        /// Process a string value
        /// </summary>
        /// <param name="stringToProcess">String</param>
        /// <returns></returns>
        protected virtual string ProcessString(string stringToProcess) {

            // Output string must not be null or empty string (from documentation)
            if (string.IsNullOrEmpty(stringToProcess)) {
                return DefaultString;
            }

            var stringBuilder = new StringBuilder(stringToProcess);

            // Dollar sign ($) should be replaced with a pound sign (£), and underscores (_) and number 4 should be removed
            _stringHelperService.ReplaceCharacters(stringBuilder, CharsToReplace);

            // Contiguous duplicate characters in the same case should  be reduced to a single character
            _stringHelperService.RemoveContiguousDuplicateCharacters(stringBuilder);

            // Should be truncated to max length of 15 chars
            _stringHelperService.TruncateString(stringBuilder, MaxLength);

            return stringBuilder.ToString();
        }

        
    }
}
