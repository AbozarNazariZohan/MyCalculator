using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using static SpecialCalculator.Constant;

namespace SpecialCalculator
{
    internal class MyUtility
    {
        /// <summary>
        ///  It fetches tiny math exp from the smallest pair of parentheses
        /// that has highest priority
        /// </summary>
        public static string FindPriorityExp(string exp)
        {
            string text = exp;

            string pattern = @"\((.*?)\)";

            MatchCollection matches = Regex.Matches(text, pattern);

            string newString = "";

            int tinyAnswer = 0;

            foreach (Match match in matches)
            {
                newString += match.Groups[1].Value + " ";
            }
            return newString;
        }

        /// <summary>
        /// It calculates math expression in the smallest parentheses 
        /// </summary>
        public static void SolveInParentheses(string exp)
        {
            int javab = 0;
            int[] javabha = new int[50];
            string tinyStr = FindPriorityExp(exp);

            // the expression that user inserts that has many small math terms
            // that needs to separate for calculating
            string[] separatedStr = tinyStr.Split();
            // counter of javab ha
            int i = 0;
            foreach (string wordd in separatedStr)
            {
                Console.Write(wordd);

                
                object result = new DataTable().Compute(wordd, null);



                if (result != DBNull.Value)  // check for empty / invalid expression
                {
                    javab = Convert.ToInt32(result);
                    javabha[i] = javab;


                }
                
                // this part wrote for test and will delete in final update
                Console.Write(" " + javab + Environment.NewLine);
                Console.WriteLine(javabha[i]);

                i++;
            }

        }

        /// <summary>
        /// final section that makes(not show) answer for output
        /// </summary>
        public static void FinalSolve(string exp)
        {
            SolveInParentheses(exp);
        }

        /// <summary>
        /// This program saves previous activities and this method
        /// saves each calculation to a file
        /// </summary>
        public static void HistorySave(string mathExpression, double answer)
        {
            File.AppendAllText(historyFileName, mathExpression + " = " + answer + Environment.NewLine);
        }

        /// <summary>
        /// This method reads previous calculation and stores it
        /// in a string to prepare it for display
        /// </summary>
        public static string HistoryShow()
        {
            string readFile = File.ReadAllText(historyFileName);
            return readFile;
        }
    }
}



