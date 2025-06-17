using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class AudioSensor : ISensor
    {
        public string Name { get; } = "audio";

        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            return weakness == InvestigationGame.Enums.SensorType.Audio;
        }
    }
}