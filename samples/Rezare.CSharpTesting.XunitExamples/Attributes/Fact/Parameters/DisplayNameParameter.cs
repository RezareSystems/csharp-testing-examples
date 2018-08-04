using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters
{
    /// <summary>
    /// The DisplayName for a test will only appear in the Visual Studio Test Explorer,
    /// not in the ReSharper Unit Test Sessions window.
    /// </summary>
    public class DisplayNameParameter
    {
        [Fact(DisplayName = "Display new name for Fact")]
        public void FactDisplayName_ChangeDisplayName_TestDisplaysNewName()
        {
            Assert.True(true);
        }
    }
}