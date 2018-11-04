using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Theory.Parameters
{
    /// <summary>
    /// As the Theory Attribute derives the Fact Attribute it has all the same parameters.
    /// </summary>
    public class DisplayNameParameter
    {
        [Theory(DisplayName = "New display name for Theory")]
        [InlineData(true)]
        public void TheoryDisplayName_ChangeDisplayName_TestDisplaysNewName(bool value) => Assert.True(value);
    }
}