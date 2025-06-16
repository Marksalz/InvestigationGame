using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class MotionSensor : ISensor
    {
        public string Name { get; } = "motion";
        private int _activations = 0;
        private const int MaxActivations = 3;
        public bool IsBroken => _activations >= MaxActivations;

        public bool Matches(string weakness)
        {
            if (IsBroken) return false;
            _activations++;
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }
    }
}