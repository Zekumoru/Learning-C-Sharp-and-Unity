using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment4
{
    /// <summary>
    /// Converts words to digits
    /// </summary>
    public class Digitizer
    {
        #region Fields

        // declare your Dictionary field and create the Dictionary object for it here
        Dictionary<string, int> digits;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Digitizer()
        {
            // populate your dictionary field here
            digits = new Dictionary<string, int>();
            digits.Add("zero", 0);
            digits.Add("one", 1);
            digits.Add("two", 2);
            digits.Add("three", 3);
            digits.Add("four", 4);
            digits.Add("five", 5);
            digits.Add("six", 6);
            digits.Add("seven", 7);
            digits.Add("eight", 8);
            digits.Add("nine", 9);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Converts the given word to the corresponding digit.
        /// If the word isn't a valid digit name, returns -1
        /// </summary>
        /// <param name="word">word to convert</param>
        /// <returns>corresponding digit or -1</returns>
        public int ConvertWordToDigit(string word)
        {
            // delete the code below and add your code
            word = word.ToLower();
            if (digits.ContainsKey(word))
            {
                return digits[word];
            }
            return -1;
        }

        #endregion
    }
}
