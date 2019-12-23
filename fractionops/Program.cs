using System;
using System.Data;

namespace fractionops
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += HandleException; //Adding a global Exception handler so that we don't have to pepper our code with try catches

            Console.WriteLine("Please Enter Fractions in the format wholeNum_numerator/denominator. Eg: 3_1/4");
            Console.WriteLine("Please 'X' to Exit\n");

           while (true)
           {
                Console.Write("\nEnter the arithmatic expression to evaluate: ");
                var input = Console.ReadLine();
                if(input.ToLower() == "x")
                    break;

                try
                {
                    Fraction result = Evaluate(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid Input: {e.Message}");
                }
            }
            Console.WriteLine("Exiting Program...");
            Console.Read();
        }

        public static Fraction Evaluate(string input)
        {
            var exprParts = input.Split(' ');

            if (exprParts.Length != 3)
            {
                throw new ArgumentException("Missing parts of the arithmatic Expression");
            }

            var left = new Fraction(exprParts[0]);
            var right = new Fraction(exprParts[2]);

            switch (exprParts[1])
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                default:
                    throw new ArgumentException("Unrecoginzed operator");
            }
        }

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            Console.WriteLine(exception != null
                ? $"FractionOps Exception: {exception}"
                : "Unknown Exception Occurred. Exiting Program");
        }
    }
}
