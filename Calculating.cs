using System.Collections.Generic;

namespace SpecialCalculator
{
    internal class Calculating
    {
        static int Priority(string oprtr)
        {
            if (oprtr == "+" || oprtr == "-") return 1;
            else if (oprtr == "*" || oprtr == "/") return 2;
            else return 0;
        }

        static List<string> Tokenize(string exp)
        {
            List<string> tokens = new List<string>();
            string number = "";

            foreach (char c in exp)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    number += c;
                }
                else
                {
                    if (number != "")
                    {
                        tokens.Add(number);
                        number = "";
                    }

                    if (!char.IsWhiteSpace(c))
                        tokens.Add(c.ToString());
                }
            }

            if (number != "")
                tokens.Add(number);

            return tokens;
        }
        static List<string> ToPostfix(List<string> tokens)
        {
            List<string> output = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (var token in tokens)
            {
                double n;
                if (double.TryParse(token, out n))
                {
                    output.Add(token);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    while (operators.Count > 0 &&
                           Priority(operators.Peek()) >= Priority(token))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Pop(); // remove "("
                }
            }

            while (operators.Count > 0)
                output.Add(operators.Pop());

            return output;
        }

        static double EvaluatePostfix(List<string> postfix)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in postfix)
            {
                double n;
                if (double.TryParse(token, out n))
                {
                    stack.Push(n);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
            }

            return stack.Pop();
        }

        public static double ParseAndSolve(string exp)
        {
            var tokens = Tokenize(exp);
            var postfix = ToPostfix(tokens);
            return EvaluatePostfix(postfix);
        }
    }
}
