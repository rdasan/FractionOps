using System;

namespace fractionops
{
    public static class MathUtil
    {
        public static long GCD(long num1, long num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);

            //Usin Euclid's algorithm 
            for (;;)
            {
                var remainder = num1 % num2;
                if (remainder == 0)
                    return num2;
                num1 = num2;
                num2 = remainder;
            }
        }

        public static long LCM(long num1, long num2)
        {
            return num1 * num2 / GCD(num1, num2);
        }

    }
}