using System;
using FluentAssertions;
using fractionops.Models;
using Xunit;

namespace fractionops.test
{
    public class AdditionTests
    {
       [Fact]
        public void Basic()
        {
            var left = new Fraction(2,4);
            var right = new Fraction(1,4);

            var result = left + right;
            result.Numerator.Should().Be(3);
            result.Denominator.Should().Be(4);
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
            var left = new Fraction(2, 3);
            var right = new Fraction(2);

            var result = left + right;
            result.Numerator.Should().Be(8);
            result.Denominator.Should().Be(3);
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
