using System;

namespace InvestigationGame
{
    public class BasicSensor : ISensor
    {
        public string Name { get; private set; }

        public BasicSensor(string name)
        {
            Name = name;
        }

        public bool Matches(string weakness)
        {
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }
    }
}