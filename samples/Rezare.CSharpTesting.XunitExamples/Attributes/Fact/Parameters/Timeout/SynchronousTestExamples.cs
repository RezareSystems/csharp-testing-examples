using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters.Timeout
{
    public class SynchronousTestExamples
    {
        /// <summary>
        /// This test is simply a demonstration that a TestTimeoutException is thrown when the Timeout is reached.
        /// A test should NOT be constructed in this fashion as Xunit handles failing the test if
        /// it takes longer than the given timeout.
        /// The only way to make this test work is by not awaiting the Assert to make the test synchronous.
        /// </summary>
        [Fact(Timeout = 50)]
        public void TimeoutLessThanProcessingTime_ThrowTestTimeoutException()
        {
            // Arrange
            var runTimeInMilliseconds = 5000;

            // Act
            Task Act() => Task.Delay(runTimeInMilliseconds);

            // Assert
            Assert.ThrowsAsync<TestTimeoutException>(Act);
        }

        [Fact(Timeout = 50)]
        public void TimeoutLessThanProcessingTime_FailTestWithTimeoutException()
        {
            // Arrange
            var runTimeInMilliseconds = 5000;
            var stopWatch = Stopwatch.StartNew();

            // Act

            // This loop is written this way, instead of putting the boolean expression in the header,
            // to remove a Roslyn S108 rule violation warning
            while (true)
            {
                if (stopWatch.ElapsedMilliseconds > runTimeInMilliseconds)
                {
                    break;
                }
            }

            stopWatch.Stop();

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// This test may require parallelization to be turned off.
        /// </summary>
        [Fact(Timeout = 50)]
        public void TimeoutLessThanProcessingTime_ThrowTestTimeoutException_RunTask()
        {
            // Arrange
            var runTimeInMilliseconds = 5000;

            // Act
            Task Act() => Task.Run(() => Thread.Sleep(runTimeInMilliseconds));

            // Assert
            Assert.ThrowsAsync<TestTimeoutException>(Act);
        }

        [Fact(Timeout = 0)]
        public void TimeoutIsZero_TimeoutNotApplied()
        {
            Assert.True(true);
        }

        [Fact(Timeout = -120)]
        public void TimeoutLessThanZero_TimeoutNotApplied()
        {
            Assert.True(true);
        }
    }
}