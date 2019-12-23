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
        public void ArithmaticOverFlowTest()
        {
            
        }
    }
}