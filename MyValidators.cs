
using System;

namespace SpecialCalculator
{
    /// <summary>
    ///  this class checks wrote for inspect
    ///  that input is correct or not
    /// </summary>
    internal class MyValidators
    {
        static int numberParentheses = 0;
        static int indexLastOpenPar = 0;

        public static bool IsInputNonNull(string inputExp) // naming conventions
        {
            if (!string.IsNullOrWhiteSpace(inputExp))
                return true;
            else
                return false;
        }


        /// <summary>
        ///  checks finally part that all parentheses has not
        ///  any problem
        /// </summary>
        /// <returns> true for Correct inserted parentheses</returns>
        public static bool IsParenthesesTrue(string exp) // takes input from user
        {
            bool IsApproved = false;

            // we should/can add new conditions with using "AND" operators
            IsApproved = IsNumParenthesesEven(exp);

            return IsApproved;
        }


        /// <summary>
        ///  checks is number of parentheses Correct
        ///  -> each true math expression has even number parentheses
        /// </summary>
        /// <param name="exp"></param>
        /// <returns> true for correct number parentheses </returns>
        public static bool IsNumParenthesesEven(string exp)
        {
            int count = 0;

            char openParentheses = '(';
            char closeParentheses = ')';


            // counting '(' in input user
            foreach (char c in exp)
            {
                if (c == openParentheses)
                {
                    count++;
                    indexLastOpenPar = count;
                }
            }

            // counting ')' in input user
            foreach (char c in exp)
            {
                if (c == closeParentheses)
                    count++;
            }

            numberParentheses = count;
            Console.WriteLine(numberParentheses);

            // sends being even parentheses result that is main
            // condition a valid math expression 
            return count % 2 == 0;

        }






    }
}
