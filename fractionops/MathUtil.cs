using System;

namespace fractionops
{
    public static class MathUtil
    {
        public static long GCD(long num1, long num2)
        {
            if (num1 == 0)
                return num2;
            if (num2 == 0)
                return num1;

            return num1 > num2 ? GCD(num1 % num2, num2) : GCD(num1, num2 % num1);
        }

        public static long LCM(long num1, long num2)
        {
            return num1 * num2 / GCD(num1, num2);
        }

    }
}