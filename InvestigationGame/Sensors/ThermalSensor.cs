using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    public class ThermalSensor : ISensor
    {
        public string Name { get; } = "thermal";
        private bool _revealed = false;

        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            return weakness == InvestigationGame.Enums.SensorType.Thermal;
        }

        // Special ability: reveals one correct sensor type from the secret list
        public string? RevealWeakness(List<InvestigationGame.Enums.SensorType> secretWeaknesses)
        {
            if (_revealed || secretWeaknesses == null || secretWeaknesses.Count == 0)
                return null;

            _revealed = true;
            foreach (var weakness in secretWeaknesses)
            {
                if (weakness == InvestigationGame.Enums.SensorType.Thermal)
                    return weakness.ToString();
            }
            return null;
        }
    }
}