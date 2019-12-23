using System;
using FluentAssertions;
using Xunit;

namespace fractionops.test
{
    public class MainProgramTests
    {
        [Theory]
        [InlineData("1/2 * 3_3/4", "1_7/8")]
        [InlineData("2_3/8 + 9/8", "3_1/2")]
        [InlineData("2_3/8                   +                   9/8", "3_1/2")]
        [InlineData("-1/2 * 3_3/4", "-1_7/8")]
        [InlineData("1 + 2", "3")]
        public void EvaluateHappyPathTests(string input, string result)
        {
            var evalResult = Program.Evaluate(input);
            evalResult.Should().Be(result);
        }

        [Theory]
        [InlineData("1/2*3_3/4")]
        [InlineData("2_ 3/8 + 9/8")]
        [InlineData("-1/2 *3_3/4")]
        [InlineData("1 + 2 * 1")]
        public void EvaluateInvalidInputsTests(string input)
        {
            Assert.Throws<ArgumentException>(() => Program.Evaluate(input));
        }

    }
}