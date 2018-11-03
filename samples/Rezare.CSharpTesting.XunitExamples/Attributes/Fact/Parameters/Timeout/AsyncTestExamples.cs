using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Fact.Parameters.Timeout
{
    /// <summary>
    /// Using the Timeout parameters is only supported when parallelization is disabled.
    /// Otheriwse undefined behaviour will occur.
    /// See: https://xunit.github.io/docs/configuring-with-json
    ///
    /// In the context of xunit.net there is no difference between async void and async Task for tests: https://github.com/xunit/xunit/issues/1405
    /// In fact, the xunit examples https://github.com/xunit/samples.xunit/blob/master/AssertExamples/AsyncExamples.cs uses async void,
    /// however, the official best practices is to use <code>async Task</code> except for asynchronous event handlers: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
    /// This issue recommends using async Task: https://github.com/xunit/xunit/issues/1390
    /// </summary>
    public class AsyncTestExamples
    {
        /// <summary>
        /// Facts the timeout timeout less than processing time test fails as execution times out asynchronous.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact(Timeout = 50)]
        public async Task TimeoutLessThanProcessingTime_TestFailsAsExecutionTimesOut_Async()
        {
            // Arrange
            var runTimeInMilliseconds = 5000;

            async Task<bool> LongRunningTaskAsync()
            {
                await Task.Delay(runTimeInMilliseconds);
                return true;
            }

            // Act
            var result = await LongRunningTaskAsync();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Facts the timeout processing time less than timeout test passes asynchronous.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact(Timeout = 5000)]
        public async Task ProcessingTimeLessThanTimeout_TestPasses_Async()
        {
            // Arrange
            var runTimeInMilliseconds = 50;

            async Task<bool> ShortRunningTaskAsync()
            {
                await Task.Delay(runTimeInMilliseconds);
                return true;
            }

            // Act
            var result = await ShortRunningTaskAsync();

            // Assert
            Assert.True(result);
        }







        /// <summary>
        /// This test will Fail as it takes longer than 50ms to run.
        /// </summary>
        [Fact(Timeout = 50)]
        public async Task TimeoutLessThanProcessingTime_TestFailsAsExecutionTimesOut()
        {
            // Arrange
            var runTimeInMilliseconds = 5000;

            // Act
            Task Act() => Task.Delay(runTimeInMilliseconds);

            // Assert
            await Act();
        }

        // Tests to include
        // async void
        // async Task
        // void
        // 
        // For each of these
        // Timeout that passes, Timeout that fails
        // test that performs an assert


        // TODO: Determine which test style should be presented and by the void approach works for the assert
        // https://github.com/xunit/xunit/commit/dabc047ce181813b886a3d0493bbeddbabf23a16
        // https://github.com/xunit/xunit/blob/master/test/test.xunit.assert/Asserts/ExceptionAssertsTests.cs#L140







        /// <summary>
        /// This test may require parallelization to be turned off.
        /// </summary>
        [Fact(Timeout = 50)]
        public async Task TimeoutLessThanProcessingTime_ThrowTestTimeoutException_2b()
        {
            // Arrange
            // Act
            Task Act() => Task.Delay(5000);

            // Assert
            await Assert.ThrowsAsync<TestTimeoutException>(Act);
        }
    }
}