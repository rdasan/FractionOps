using System;

namespace fractionops
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += HandleException; //Adding a global Exception handler so that we don't have to pepper our code with try catches
        }

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            if (exception != null)
            {
                Console.WriteLine($"FractionOps Exception: {exception}");
            }
            else
            {
                Console.WriteLine("Unknown Exception Occurred. Exiting Program");
            }
                
        }
    }
}
