using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class PulseSensor : ISensor
    {
        public string Name { get; } = "pulse";
        private int _activations = 0;
        private const int MaxActivations = 3;
        public bool IsBroken => _activations >= MaxActivations;

        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            if (IsBroken) return false;
            _activations++;
            return weakness == InvestigationGame.Enums.SensorType.Pulse;
        }
    }
}