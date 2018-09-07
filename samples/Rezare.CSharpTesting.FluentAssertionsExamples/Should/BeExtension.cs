using FluentAssertions;
using Xunit;

namespace Rezare.CSharpTesting.FluentAssertionsExamples.Should
{
    public class BeExtension
    {
        [Theory]
        [InlineData("test", "test")]
        [InlineData("trailing whitespace   ", "trailing whitespace   ")]
        public void Be_StringCheck_ExactlyTheSame(
            string result,
            string expected)
        {
            result.Should().Be(expected);
        }

        [Trait("Demonstration Tests", "Purposely Failing")]
        [Fact]
        public void Be_StringCheckWithBecause_ExactlyTheSame_FailPurposely()
        {
            var becauseMessage = "numbers go before letters";

            "test123".Should().Be("123test", becauseMessage);
        }

        [Trait("Demonstration Tests", "Purposely Failing")]
        [Fact]
        public void Be_StringCheckWithBecauseAndParams_ExactlyTheSame_FailPurposely()
        {
            var becauseMessage = "{0} should be {1} before {2}";
            var becauseParams = new object[] { typeof(string), "numbers", "letter" };

            "123test".Should().Be("123test", becauseMessage, becauseParams);
        }

        [Trait("Demonstration Tests", "Purposely Failing")]
        [Fact]
        public void Be_StringCheckWithBecauseAndParamsArray_ExactlyTheSame_FailPurposely()
        {
            var becauseMessage = "{0} should be {1} before {2}";

            "test123".Should().Be("123test", becauseMessage, typeof(string), "numbers", "letter");
        }
    }
}