namespace BalancedBias.Common.Sample
{
    public class SampleClass : ISampleClass
    {
        private readonly string _name;

        public SampleClass(string name)
        {
            _name = name;
        }

        public string SayName()
        {
            return _name;
        }
    }
}
