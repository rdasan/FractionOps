using System;
using FluentAssertions;
using fractionops.Models;
using Xunit;

namespace fractionops.test
{
    public class FractionTests
    {
       [Fact]
        public void AdditionOperatorSimpleTest()
        {
            var left = new Fraction(2,4);
            var right = new Fraction(1,4);

            var result = left + right;
            result.Numerator.Should().Be(3);
            result.Denominator.Should().Be(4);
        }
    }
}
