using Xunit;

namespace Rezare.CSharpTesting.XunitExamples.Attributes.Theory.Generics
{
    public class GenericTestParameterExamples
    {
        // https://github.com/xunit/xunit/issues/1378
        // https://stackoverflow.com/questions/39570641/xunit-theory-test-using-generics
        // https://stackoverflow.com/questions/2364929/nunit-testcase-with-generics/43339950#43339950

        [Theory]
        [MemberData(nameof(GenericValueScenarios))]
        public void UnitBeingTested_StateUnderTest_ExpectedBehaviour()
        {
            // Arrange


            // Act


            // Assert
        }

        // Cases to demonstrate
        // when would this type of test normally be done?
        public void GenericsTheoryInlineData<T>(T param)
        {
        }

        public void GenericsTheoryMemberData<T, T2>(T param, T2 param2)
        {
        }

        // Add this, but put a note that it is not implemented and will unlikely be
        // as there is no likely reason for doing this type of test
        public void GenericsTheoryMemberData<T>()
        {
        }

        public void GenericsTheoryMemberData<T>(string blah)
        {
        }


        public TheoryData<object> GenericValueScenarios()
        {
            var td = new TheoryData<object>
            {
                1.23,
                7,
                "string"
            };

            return td;
        }
    }
}