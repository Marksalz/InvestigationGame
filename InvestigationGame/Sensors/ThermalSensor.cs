using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    public class ThermalSensor : ISensor
    {
        public string Name { get; } = "thermal";
        private bool _revealed = false;

        public bool Matches(string weakness)
        {
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }

        // Special ability: reveals one correct sensor type from the secret list
        public string? RevealWeakness(List<string> secretWeaknesses)
        {
            if (_revealed || secretWeaknesses == null || secretWeaknesses.Count == 0)
                return null;

            _revealed = true;
            // Reveal the first matching weakness for simplicity
            foreach (var weakness in secretWeaknesses)
            {
                if (Name.Equals(weakness, StringComparison.OrdinalIgnoreCase))
                    return weakness;
            }
            return null;
        }
    }
}