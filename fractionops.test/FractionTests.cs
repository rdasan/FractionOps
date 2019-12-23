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

        [Fact]
        public void WholeNumberToFractionTest()
        {
            var fraction = new Fraction("4");

            fraction.Numerator.Should().Be(4);
            fraction.Denominator.Should().Be(1);
        }

        [Theory]
        [InlineData("erwgfugreg/gvfhywg")]
        [InlineData("4\\5")]
        [InlineData(@"8\9")]
        [InlineData("5/6/7")]
        [InlineData("5_6/7_")]
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

        [Fact]
        public void MixedFractionStringToFractionTest2()
        {
            var fraction = new Fraction("3_4"); //this is equivalaent to "3_4/1"

            fraction.Numerator.Should().Be(7);
            fraction.Denominator.Should().Be(1);
        }

        [Fact]
        public void MixedFractionStringToReducedFractionTest()
        {
            var fraction = new Fraction("3_2/2");

            fraction.Numerator.Should().Be(4);
            fraction.Denominator.Should().Be(1);
        }

    }
}