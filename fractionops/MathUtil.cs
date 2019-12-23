using System;

namespace fractionops
{
    public static class MathUtil
    {
        public static long GCD(long num1, long num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);

            while (num1 != 0 && num2 != 0)
            {
                if (num1 > num2)
                    num1 %= num2;
                else
                    num2 %= num1;
            }

            return num1 == 0 ? num2 : num1;
        }

    }
}