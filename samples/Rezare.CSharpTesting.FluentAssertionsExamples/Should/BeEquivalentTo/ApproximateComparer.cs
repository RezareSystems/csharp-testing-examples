using System.Collections.Generic;
using FluentAssertions;
using Rezare.CSharpTesting.FluentAssertionsExamples.Extensions;
using Xunit;

namespace Rezare.CSharpTesting.FluentAssertionsExamples.Should
{
    /// <summary>
    /// TODO: come up with a better name for this class
    /// </summary>
    public class ApproximateComparer
    {
        [Fact]
        public void DictionaryComparisonUsingAssertionContext_ValuesApproximatelyTheSame_DictionariesAreEquivalent()
        {
            // Arrange
            var dictOne = new Dictionary<string, double>
            {
                ["a"] = 1.2345,
                ["b"] = 2.4567,
                ["c"] = 5.6789,
                ["s"] = 3.333
            };

            // Act
            var dictTwo = new Dictionary<string, double>
            {
                ["a"] = 1.2348,
                ["b"] = 2.4561,
                ["c"] = 5.679,
                ["s"] = 3.333
            };

            // Assert
            dictOne.Should().BeEquivalentTo(dictTwo, options => options
                .Using<double>(ctx => ctx.ApproximatelyCompareDouble(1e-2))
                .WhenTypeIs<double>()
            );
        }

        /// <summary>
        /// TODO: redo this test but keep assertion
        /// Dictionaries the comparison values approximately the same dictionaries are equivalent.
        /// </summary>
        public void DictionaryComparison_ValuesApproximatelyTheSame_DictionariesAreEquivalent()
        {
            // Arrange
            var expected = new Dictionary<string, double>
            {
                { "a", 1.2345 },
                { "b", 2.4567 },
                { "c", 5.6789 },
                { "s", 3.333 }
            };

            // Act
            var result = new Dictionary<string, double>
            {
                { "a", 1.2348 },
                { "b", 2.4561 },
                { "c", 5.679 },
                { "s", 3.333 }
            };

            // Assert
            result.Should().BeEquivalentTo(expected, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 1e-2))
                .WhenTypeIs<double>());
        }
    }
}
