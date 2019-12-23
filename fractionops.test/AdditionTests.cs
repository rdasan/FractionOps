using FluentAssertions;
using Xunit;

namespace fractionops.test
{
    public class AdditionTests
    {
       [Fact]
        public void Basic()
        {
            var left = new Fraction(1,4);
            var right = new Fraction(1,4);

            var result = left + right;
            result.Numerator.Should().Be(1);
            result.Denominator.Should().Be(2);
        }

        [Fact]
        public void NegativeNumerator()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(-1, 4);

            var result = left + right;
            result.Numerator.Should().Be(1);
            result.Denominator.Should().Be(4);
        }

        [Fact]
        public void NegativeDenominator()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(1, -4);

            var result = left + right;
            result.Numerator.Should().Be(1);
            result.Denominator.Should().Be(4);
        }

        [Fact]
        public void NegativeLHS()
        {
            var left = new Fraction(-2, 4);
            var right = new Fraction(1, 4);

            var result = left + right;
            result.Numerator.Should().Be(-1);
            result.Denominator.Should().Be(4);
        }

        [Fact]
        public void LHS_Whole_RHS_Fraction()
        {
            var left = new Fraction(2);
            var right = new Fraction(1, 4);

            var result = left + right;
            result.Numerator.Should().Be(9);
            result.Denominator.Should().Be(4);
        }

        [Fact]
        public void LHS_Fraction_RHS_Whole()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(2);

            var result = left + right;
            result.Numerator.Should().Be(5);
            result.Denominator.Should().Be(2);
        }

        [Fact]
        public void LHS_RHS_Whole()
        {
            var left = new Fraction(2);
            var right = new Fraction(5);

            var result = left + right;
            result.Numerator.Should().Be(7);
            result.Denominator.Should().Be(1);
        }
    }
}
