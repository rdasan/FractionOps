using System;
using System.Linq;

namespace fractionops
{
    public static class FractionExtensions
    {
        private const string _error = "Invalid Fraction String";
        public static Fraction ToFraction(this string fractionText, Fraction fraction)
        {
            if (!fractionText.Contains('_')) 
                return GetFraction(fractionText, fraction);

            var count = Count(fractionText, '_');
            if(count > 1)
                throw new ArgumentException(_error);

            var mixedParts = fractionText.Split('_');
            var wholeNumPart = long.Parse(mixedParts[0]);
            var fractionPart = GetFraction(mixedParts[1], fraction);
            fraction.Numerator = (fractionPart.Denominator * wholeNumPart) + fractionPart.Numerator;
            return fraction.Reduce();
        }

        private static Fraction GetFraction(string fractionText, Fraction fraction)
        {
            string[] parts = fractionText.Split('/');

            if (parts.Length > 2)
                throw new ArgumentException(_error);

            if (!long.TryParse(parts[0], out long numerator))
                throw new ArgumentException(_error);

            fraction.Numerator = numerator;
            if (parts.Length == 1)
            {
                fraction.Denominator = 1;
                return fraction;
            }

            if (!long.TryParse(parts[1], out long denominator))
                throw new ArgumentException(_error);

            fraction.Denominator = denominator;
            return fraction;
        }

        private static int Count(string s, char c)
        {
            return s.Count(t => t == c);
        }

        public static Fraction Reduce(this Fraction fraction)
        {
            switch (fraction.Denominator)
            {
                case 0:
                    throw new DivideByZeroException("Denominator cannot be zero");
                case 1:
                    return fraction;
            }

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