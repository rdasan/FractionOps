using System;
using System.Collections.Generic;
using System.Text;

namespace fractionops.Models
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
            Reduce();
        }

        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            Reduce();
        }

        public Fraction(long number)
        {
            Numerator = number;
            Denominator = 1;
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            var gcdDenom = MathUtil.GCD(left.Denominator, right.Denominator);
            checked
            {
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

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }

        private void Reduce()
        {
            if(Denominator == 1)
                return;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }

            var gcd = MathUtil.GCD(Numerator, Denominator);

            if(gcd == 1)
                return;

            Numerator /= gcd;
            Denominator /= gcd;
        }
    }
}
