using InvestigationGame.Interface;
using System;

namespace InvestigationGame.Sensors
{
    public class BasicSensor : ISensor
    {
        public string Name { get; private set; }

        public BasicSensor(string name)
        {
            Name = name;
        }

        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            return Name.Equals(weakness.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}