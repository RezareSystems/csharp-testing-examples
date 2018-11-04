using System;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace Rezare.CSharpTesting.FluentAssertionsExamples.Extensions
{
    public static class BeEquivalentToExtensions
    {
        public static void ApproximatelyCompareDouble(this IAssertionContext<double> ctx, double precision)
        {
            var bothNaN = double.IsNaN(ctx.Subject) && double.IsNaN(ctx.Expectation);
            var bothPositiveInf = double.IsPositiveInfinity(ctx.Subject) && double.IsPositiveInfinity(ctx.Expectation);
            var bothNegativeInf = double.IsNegativeInfinity(ctx.Subject) && double.IsNegativeInfinity(ctx.Expectation);
            var withinPrecision = Math.Abs(ctx.Subject - ctx.Expectation) <= precision;

            Execute.Assertion
                .BecauseOf(ctx.Because, ctx.BecauseArgs)
                .ForCondition(bothNaN || bothPositiveInf || bothNegativeInf || withinPrecision)
                .FailWith("Expected {context:double} to be {0} +/- {1} {reason}, but found {2}", ctx.Subject, precision, ctx.Expectation);
        }
    }
}