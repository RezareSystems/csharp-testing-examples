using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters
{
    public class SkipExamples
    {
        [Fact(Skip = "Skip passing test")]
        public void SkipPassingTestWithReason_TestSkippedWithReasonInOutput()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip failing test")]
        public void SkipFailingTestWithReason_TestSkippedWithReasonInOutput()
        {
            Assert.True(false);
        }

        [Fact(Skip = "")]
        public void SkipPassingTestWithEmptyReason_TestRunsAndPasses()
        {
            Assert.True(true);
        }

        [Fact(Skip = "")]
        public void SkipFailingTestWithEmptyReason_TestRunsAndFails()
        {
            Assert.True(false);
        }

        [Fact(Skip = "Empty test")]
        public void SkipEmptyTest_TestIsSkipped()
        {
        }
    }
}