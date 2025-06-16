using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class MagneticSensor : ISensor
    {
        public string Name { get; } = "magnetic";
        private int _counterCancelUses = 0;
        private const int MaxCancels = 2;

        public bool Matches(string weakness)
        {
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }

        // Call this when a counterattack would occur
        public bool TryCancelCounterAttack(string weakness)
        {
            if (_counterCancelUses < MaxCancels && Matches(weakness))
            {
                _counterCancelUses++;
                return true;
            }
            return false;
        }
    }
}