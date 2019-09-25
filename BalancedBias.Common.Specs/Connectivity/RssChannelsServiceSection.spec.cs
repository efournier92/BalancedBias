using System;
using System.Configuration;
using BalancedBias.Common.Config;
using BalancedBias.Common.Sample;
using NUnit.Framework;
using Spec.Library;

namespace BalancedBias.Common.Specs.Connectivity
{
    [TestFixture]
    public class When_reading_rss_channels : ContextSpecification<RssChannelsServiceSection>
    {
        private string _name;
        private string _result;

        protected override void Context()
        {
        }


        protected override void Because()
        {
            _result = sut.GetTemplateByChannelName("nyTimes");
        }


        protected override RssChannelsServiceSection CreateSUT()
        {
            return (RssChannelsServiceSection)ConfigurationManager.GetSection("rssChannelsService");

        }

        [Observation]
        public void Should_return_the_name_with_hello_and_space_as_prefix()
        {
            _result.ShouldEqual("Generic");
        }
    }
    
    public class W : Attribute
    {
    }
}