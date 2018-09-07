using FluentAssertions;
using Xunit;

namespace Rezare.CSharpTesting.FluentAssertionsExamples.Should
{
    public class BeExtension
    {
        [Theory]
        [InlineData("test", "test")]
        [InlineData("trailing whitespace   ", "trailing whitespace   ")]
        public void BeExtensionExample_StringType_AssertStringsAreExactlyTheSame(
            string result,
            string expected)
        {
            result.Should().Be(expected);
        }

        [Fact]
        public void BeExtensionExample_StringTypeWithBecause_AssertStringsAreExactlyTheSame()
        {
            var becauseMessage = "the strings should be exactly the same";

            "test123".Should().Be("test123", becauseMessage);
        }

        [Trait("Demonstration Tests", "Purposely Failing")]
        [Fact]
        public void BeExtensionExample_StringTypeWithBecause_AssertStringsAreExactlyTheSame_FailPurposely()
        {
            var becauseMessage = "the strings should be exactly the same";

            "test123".Should().Be("123test", becauseMessage);
        }
    }
}