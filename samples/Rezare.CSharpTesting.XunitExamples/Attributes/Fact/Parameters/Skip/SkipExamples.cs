using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters.Skip
{
    /// <summary>
    /// Examples of how to use the Skip attribute.
    /// </summary>
    public class SkipExamples
    {
        /// <summary>
        /// Skips a passing test with the provided reason being displayed in output.
        /// </summary>
        [Fact(Skip = "Skip passing test")]
        public void SkipPassingTest_WithReason_TestSkippedWithReasonInOutput() => Assert.True(true);

        /// <summary>
        /// Skips a failing test with the provided reason being displayed in output.
        /// </summary>
        [Fact(Skip = "Skip failing test")]
        public void SkipFailingTest_WithReason_TestSkippedWithReasonInOutput() => Assert.True(false);

        /// <summary>
        /// Runs a passing test as it has an empty Skip reason.
        /// </summary>
        /// <remarks>
        /// The Xunit TestRunner uses <c>string.IsNullOrEmpty(SkipReason)</c> to determine if a test should be run.
        /// Meaning that tests with an empty string for the Skip Reason are not skipped.
        /// </remarks>
        [Fact(Skip = "")]
        public void SkipPassingTest_EmptyReason_TestRunsAndPasses() => Assert.True(true);

        /// <summary>
        /// Runs a failing test as it has an empty Skip reason.
        /// </summary>
        /// <remarks>
        /// The Xunit TestRunner uses <c>string.IsNullOrEmpty(SkipReason)</c> to determine if a test should be run.
        /// Meaning that tests with an empty string for the Skip Reason are not skipped.
        /// </remarks>
        [Fact(Skip = "")]
        public void SkipFailingTest_EmptyReason_TestRunsAndFails() => Assert.True(false);

        /// <summary>
        /// Test with Skip set to null.
        /// </summary>
        /// <remarks>
        /// Null is the default value for Skip, so Skip is ignored.
        /// </remarks>
        [Fact(Skip = null)]
        public void SkipPassingTest_SkipIsNull_TestRunsAndPasses() => Assert.True(true);

        /// <summary>
        /// Skips an empty test with a reason.
        /// </summary>
        [Fact(Skip = "Empty test")]
        public void SkipEmptyTest_WithReason_TestIsSkipped()
        {
            // Demonstrate how an empty skipped test operates.
        }
    }
}