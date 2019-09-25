using BalancedBias.Common;
using NUnit.Framework;
using Spec.Library;

namespace Runtime.Specs
{
    [TestFixture]
    public class When_calling_ClickCampaign_Service_test_method_with_a_name : ContextSpecification<ITestClass>
    {
        private string name;
        private string result;

        protected override void Context()
        {
            name = "Chester";
        }


        protected override void Because()
        {
            result = sut.SayName(); 
        }


        protected override ITestClass CreateSUT()
        {
            return new TestClass("Chester");
        }

        [Test]
        public void Should_return_the_name_with_hello_and_space_as_prefix()
        {
            result.ShouldBeEmpty();
        }
    }
}
