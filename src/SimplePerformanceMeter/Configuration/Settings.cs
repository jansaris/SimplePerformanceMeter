namespace SimplePerformanceMeter.Configuration
{
    public class Settings : ISettings
    {
        public int Delay => 1000;
        public bool Processor => true;
        public bool Memory => true;
    }
}