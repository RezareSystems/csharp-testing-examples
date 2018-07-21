using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters
{
    public class SkipParameter
    {
        [Fact(Skip = "Skip passing test")]
        public void SkipFactTest_SkipPassingTestWithReason_TestSkippedWithReasonInOutput()
        {
            Assert.True(true);
        }

        [Fact(Skip = "Skip failing test")]
        public void SkipFactTest_SkipFailingTestWithReason_TestSkippedWithReasonInOutput()
        {
            Assert.True(false);
        }

        [Fact(Skip = "")]
        public void SkipFactTest_SkipPassingTestWithEmptyReason_TestRunsAndPasses()
        {
            Assert.True(true);
        }

        [Fact(Skip = "")]
        public void SkipFactTest_SkipFailingTestWithEmptyReason_TestRunsAndFails()
        {
            Assert.True(false);
        }

        [Fact(Skip = "Empty test")]
        public void SkipFactTest_SkipEmptyTest_TestIsSkipped()
        {
        }
    }
}