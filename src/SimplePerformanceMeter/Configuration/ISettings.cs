﻿namespace SimplePerformanceMeter.Configuration
{
    public interface ISettings
    {
        int Delay { get; } 
        bool Processor { get; }
        bool Memory { get; }
    }
}