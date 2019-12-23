using System;

namespace fractionops
{
    public static class FractionExtensions
    {
        public static Fraction ToFraction(this string fractionText, Fraction fraction)
        {
            string[] parts = fractionText.Split('/');

            if (long.TryParse(parts[0], out long numerator) && long.TryParse(parts[1], out long denominator))
            {
                fraction.Numerator = numerator;
                fraction.Denominator = denominator;
                return fraction?.Reduce();
            }
            throw new ArgumentException("Invalid Fraction String");
        }

        public static Fraction Reduce(this Fraction fraction)
        {
            if (fraction.Denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero");
            }

            if (fraction.Denominator == 1)
                return fraction;

            if (fraction.Denominator < 0)
            {
                fraction.Numerator = -fraction.Numerator;
                fraction.Denominator = -fraction.Denominator;
            }

            var gcd = MathUtil.GCD(fraction.Numerator, fraction.Denominator);

            if (gcd == 1)
                return fraction;

            fraction.Numerator /= gcd;
            fraction.Denominator /= gcd;
            return fraction;
        }
    }
}