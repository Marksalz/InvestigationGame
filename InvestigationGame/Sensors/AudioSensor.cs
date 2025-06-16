using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class AudioSensor : ISensor
    {
        public string Name { get; } = "audio";

        public bool Matches(string weakness)
        {
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }
    }
}