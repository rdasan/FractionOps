using System;
using Microsoft.VisualBasic.CompilerServices;

namespace fractionops
{
    public class Fraction 
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }

        public Fraction(string fractionText)
        {
            var parts = fractionText.Split('/');
            if (long.TryParse(parts[0], out long numerator))
                Numerator = numerator;
            if (long.TryParse(parts[1], out long denominator))
                Denominator = denominator;

            this.Reduce();
        }

        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            this.Reduce();
        }

        public Fraction(long number)
        {
            Numerator = number;
            Denominator = 1;
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            checked
            {
                var gcdDenom = MathUtil.GCD(left.Denominator, right.Denominator);
                var numerator = left.Numerator * (right.Denominator / gcdDenom) +
                                right.Numerator * (left.Denominator / gcdDenom);

                var denominator = left.Denominator * (right.Denominator / gcdDenom);
                return new Fraction(numerator, denominator);
            }
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            return left + -right;
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            checked
            {
                var numerator = left.Numerator * right.Numerator;
                var denominator = left.Denominator * right.Denominator;

                return new Fraction(numerator, denominator);
            }
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left * new Fraction(right.Denominator, right.Numerator);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }
    }
}
