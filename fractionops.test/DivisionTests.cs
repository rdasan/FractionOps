using System;
using FluentAssertions;
using Xunit;

namespace fractionops.test
{
    public class DivisionTests
    {
        [Fact]
        public void Basic()
        {
            var left = new Fraction(1, 4);
            var right = new Fraction(1, 4);

            var result = left / right;
            result.Numerator.Should().Be(1);
            result.Denominator.Should().Be(1);

        }

        [Fact]
        public void BasicReduced()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(5, 4);

            var result = left / right;
            result.Numerator.Should().Be(2);
            result.Denominator.Should().Be(5);

        }

        [Fact]
        public void NegativeNumerator()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(-1, 4);

            var result = left / right;
            result.Numerator.Should().Be(-2);
            result.Denominator.Should().Be(1);
        }

        [Fact]
        public void NegativeDenominator()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(1, -4);

            var result = left / right;
            result.Numerator.Should().Be(-2);
            result.Denominator.Should().Be(1);
        }

        [Fact]
        public void NegativeLHS()
        {
            var left = new Fraction(-2, 4);
            var right = new Fraction(1, 4);

            var result = left / right;
            result.Numerator.Should().Be(-2);
            result.Denominator.Should().Be(1);
        }

        [Fact]
        public void LHS_Whole_RHS_Fraction()
        {
            var left = new Fraction(2);
            var right = new Fraction(1, 4);

            var result = left / right;
            result.Numerator.Should().Be(8);
            result.Denominator.Should().Be(1);
        }

        [Fact]
        public void LHS_Fraction_RHS_Whole()
        {
            var left = new Fraction(2, 4);
            var right = new Fraction(2);

            var result = left / right;
            result.Numerator.Should().Be(1);
            result.Denominator.Should().Be(4);
        }

        [Fact]
        public void LHS_RHS_Whole()
        {
            var left = new Fraction(2);
            var right = new Fraction(5);

            var result = left / right;
            result.Numerator.Should().Be(2);
            result.Denominator.Should().Be(5);
        }

        [Fact]
        public void ArithmaticOverFlowTest()
        {
            var left = new Fraction(1,long.MaxValue);
            var right = new Fraction(long.MaxValue);

            Assert.Throws<OverflowException>(() => left / right);
        }
    }
}