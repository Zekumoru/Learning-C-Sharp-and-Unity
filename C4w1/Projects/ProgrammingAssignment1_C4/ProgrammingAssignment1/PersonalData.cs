using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// A class holding personal data for a person
    /// </summary>
    public class PersonalData
    {
        #region Fields

        // declare your fields here
        string firstName = "";
        string middleName = "";
        string lastName = "";
        string streetAddress = "";
        string city = "";
        string state = "";
        string postalCode = "";
        string country = "";
        string phoneNumber = "";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the person's first name
        /// </summary>
        public string FirstName
        {
            get 
            {
                // delete code below and replace with correct code
                return firstName;
            }
        }

        /// <summary>
        /// Gets the person's middle name
        /// </summary>
        public string MiddleName
        {
            get
            {
                // delete code below and replace with correct code
                return middleName;
            }
        }

        /// <summary>
        /// Gets the person's last name
        /// </summary>
        public string LastName
        {
            get
            {
                // delete code below and replace with correct code
                return lastName;
            }
        }

        /// <summary>
        /// Gets the person's street address
        /// </summary>
        public string StreetAddress
        {
            get
            {
                // delete code below and replace with correct code
                return streetAddress;
            }
        }

        /// <summary>
        /// Gets the person's city or town
        /// </summary>
        public string City
        {
            get
            {
                // delete code below and replace with correct code
                return city;
            }
        }

        /// <summary>
        /// Gets the person's state or province
        /// </summary>
        public string State
        {
            get
            {
                // delete code below and replace with correct code
                return state;
            }
        }

        /// <summary>
        /// Gets the person's postal code
        /// </summary>
        public string PostalCode
        {
            get
            {
                // delete code below and replace with correct code
                return postalCode;
            }
        }

        /// <summary>
        /// Gets the person's country
        /// </summary>
        public string Country
        {
            get
            {
                // delete code below and replace with correct code
                return country;
            }
        }

        /// <summary>
        /// Gets the person's phone number (digits only, no 
        /// parentheses, spaces, or dashes)
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                // delete code below and replace with correct code
                return phoneNumber;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// Reads personal data from a file. If the file
        /// read fails, the object contains an empty string for all
        /// the personal data
        /// </summary>
        /// <param name="fileName">name of file holding personal data</param>
        public PersonalData(string fileName)
        {
            // your code can assume we know the order in which the
            // values appear in the string; it's the same order as
            // they're listed for the properties above. We could do 
            // something more complicated with the names and values, 
            // but that's not necessary here

            // IMPORTANT: The mono compiler the automated grader uses
            // does NOT support the string Split method. You have to 
            // use the IndexOf method to find comma locations and the
            // Substring method to chop off the front of the string
            // after you extract each value to extract and save the
            // personal data

            StreamReader input = null;
            try
            {
                // open file
                input = File.OpenText(fileName);

                // go each line then split
                string[] values = Split(input.ReadLine(), ',');

                // assign fields
                // format: 0 <first name>
                firstName = values[0];

                //         1 <middle name>
                middleName = values[1];

                //         2 <last name>
                lastName = values[2];

                //         3 <street address>
                streetAddress = values[3];

                //         4 <city>
                city = values[4];

                //         5 <state>
                state = values[5];

                //         6 <postal code>
                postalCode = values[6];

                //         7 <country>
                country = values[7];

                //         8 <phone number>
                phoneNumber = values[8];
            }
            catch (Exception ex)
            {
                // do nothing...
            }
            finally
            {
                // close file if opened
                if (input != null)
                {
                    input.Close();
                }
            }
        }

        /// <summary>
        /// Returns a string array that contains substrings
        /// delimited by the delimiter.
        /// </summary>
        /// <param name="toSplit">string to split</param>
        /// <param name="delimiter">delimeter</param>
        string[] Split(string toSplit, char delimiter)
        {
            // get how many times the delimiter shows up
            int countDelim = 1;
            foreach (char c in toSplit) if (c == delimiter) countDelim++;

            // create string appropriate size and declare variables
            string[] tokens = new string[countDelim];
            int indexToken, indexStart, indexDelim;

            // split string
            for (indexToken = 0, indexStart = 0, indexDelim = 0 ; (indexDelim = 
                toSplit.IndexOf(delimiter, indexStart)) != -1; indexToken++)
            {
                tokens[indexToken] = toSplit.Substring(indexStart, indexDelim - indexStart);
                indexStart = indexDelim + 1;
            }
            tokens[indexToken] = toSplit.Substring(indexStart);

            return tokens;
        }

        #endregion
    }
}
