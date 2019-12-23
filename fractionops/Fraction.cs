using System;

namespace fractionops
{
    public class Fraction 
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }

        public Fraction(string fractionText)
        {
            fractionText.ToFraction(this);
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

        public override string ToString()
        {
            if (Denominator == 1)
                return $"{Numerator}";

            long numeratorAbs = Math.Abs(Numerator);
            long denominatorAbs = Math.Abs(Denominator);

            if (numeratorAbs > denominatorAbs) //Improper Fraction
            {
                //Convert to Mixed Fraction
                long wholeNumPart = numeratorAbs / denominatorAbs;
                long remainder = numeratorAbs % denominatorAbs;
                if (Numerator < 0)
                    wholeNumPart *= -1;
                return $"{wholeNumPart}_{remainder}/{Denominator}";
            }

            return $"{Numerator}/{Denominator}";
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
