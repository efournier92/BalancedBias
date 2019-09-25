using BalancedBias.Common.Sample;
using NUnit.Framework;
using Spec.Library;

namespace BalancedBias.Common.Specs.Sample
{
    [TestFixture]
    public class When_testing_spec_architecture : ContextSpecification<ISampleClass>
    {
        private string _name;
        private string _result;

        protected override void Context()
        {
            _name = "Spec.Library";
        }


        protected override void Because()
        {
            _result = sut.SayName();
        }


        protected override ISampleClass CreateSUT()
        {
            return new SampleClass("Spec.Library");
        }

        [Observation]
        public void Should_return_the_name_with_hello_and_space_as_prefix()
        {
            _result.ShouldEqual(_name);
        }
    }
}
