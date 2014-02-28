using System;
using System.Security.Cryptography;
using System.Text;

namespace UnitTest.Utils.TestData
{
    /// <summary>
    /// Creates random data for general system objects
    /// </summary>
    public static class CommonTestData
    {
        #region Public Methods

        /// <summary>
        /// Create a random number as a string with a maximum length.
        /// </summary>
        /// <param name="length">Length of number</param>
        /// <returns>Generated string</returns>
        public static string GeneratRandomNumber(int length)
        {
            if (length > 0)
            {
                var sb = new StringBuilder();

                var rnd = SeedRandom();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(rnd.Next(0, 9).ToString());
                }

                return sb.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Generates a random integer. The value is simply within int range.
        /// </summary>
        /// <returns></returns>
        public static int GeneratRandomInt()
        {
            var rnd = SeedRandom();
            return rnd.Next();
        }

        /// <summary>
        /// Gets a string from the English alphabet at random
        /// </summary>
        public static string GenerateRandomAlphabetString(int length)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rnd = SeedRandom();

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rnd.Next(allowedChars.Length)];
            }

            return new string(chars);
        }

        /// <summary>
        /// Create a random boolean.
        /// </summary>
        /// <returns>random boolean</returns>
        public static bool GenerateRandomBoolean()
        {
            // Create a byte array as a data source
            var rnd = SeedRandom();
            return rnd.Next(0, 2) == 0;
        }

        /// <summary>
        /// Create a random DateTime in the past, maximum 100 days ago.
        /// </summary>
        /// <returns>random boolean</returns>
        public static DateTime GenerateRandomDateInThePast()
        {
            int daysAgo = int.Parse(GeneratRandomNumber(2));
            return DateTime.Now.Date.AddDays(-daysAgo);
        }

        public static string GenerateRandomEmail()
        {
            return string.Format("{0}@{1}.com", GenerateRandomAlphabetString(10), GenerateRandomAlphabetString(10));
        }

        public static string GenerateRandomMobileNumber()
        {
            return string.Format("04{0}", GeneratRandomNumber(8));
        }

        /// <summary>
        /// Create a random string with a maximum length.
        /// </summary>
        /// <param name="length">Max length of random string</param>
        /// <returns>Generated string</returns>
        public static string GenerateRandomString(int length)
        {
            // Create a byte array as a data source
            byte[] tmpSource = Encoding.ASCII.GetBytes(DateTime.Now.Ticks.ToString());

            byte[] tmpHash = new SHA512Managed().ComputeHash(tmpSource);
            string result = Convert.ToBase64String(tmpHash);

            if (result.Length > length)
            {
                result = result.Substring(0, length);
            }

            return result;
        }

        public static string GenerateRandomPhoneNumber()
        {
            return string.Format("07{0}", GeneratRandomNumber(8));
        }

        #endregion

        #region Methods

        private static Random SeedRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        #endregion
    }
}