using System;
using FluentAssertions;
using Xunit;

namespace fractionops.test
{
    public class FractionTests
    {
        [Fact]
        public void DivideByZeroExceptionTest()
        {
            Action action = () => new Fraction(2,0);
            action.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void StringToFractionTest()
        {
            var fraction = new Fraction("1/4");

            fraction.Numerator.Should().Be(1);
            fraction.Denominator.Should().Be(4);
        }

        [Fact]
        public void StringToNegativeFractionTest()
        {
            var fraction = new Fraction("-1/4");

            fraction.Numerator.Should().Be(-1);
            fraction.Denominator.Should().Be(4);
        }

        [Theory]
        [InlineData("erwgfugreg/gvfhywg")]
        [InlineData("4_5")]
        [InlineData("4\\5")]
        [InlineData(@"8\9")]
        public void InvalidFractionStringTest(string fractionText)
        {
            Action action = () => new Fraction(fractionText);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void MixedFractionStringToFractionTest()
        {
            var fraction = new Fraction("3_1/4");

            fraction.Numerator.Should().Be(13);
            fraction.Denominator.Should().Be(4);
        }

    }
}