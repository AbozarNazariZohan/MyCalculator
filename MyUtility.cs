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
        ///  fetches tiny math exp from smallest couple parentheses
        // that has highest priority
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

        public static void SolveInParentheses(string exp)
        {
            int javab = 0;
            int[] javabha = new int[50];
            string tinyStr = FindPriorityExp(exp);
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

                Console.Write(" " + javab + Environment.NewLine);
                Console.WriteLine(javabha[i]);

                i++;
            }

        }

        public static void FinalSolve(string exp)
        {
            SolveInParentheses(exp);
        }

        public static void HistorySave(string mathExpression, double answer)
        {
            File.AppendAllText(historyFileName, mathExpression + " = " + answer + Environment.NewLine);
        }


        public static string HistoryShow()
        {
            string readFile = File.ReadAllText(historyFileName);
            return readFile;
        }
    }
}
