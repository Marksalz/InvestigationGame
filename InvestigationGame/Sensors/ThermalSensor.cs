using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a thermal sensor in the Investigation Game.
    /// </summary>
    public class ThermalSensor : ISensor
    {
        public string Name { get; } = "thermal";
        private bool _revealed = false;

        /// <summary>
        /// A method to check if the sensor matches a given weakness type.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(Enums.SensorType weakness)
        {
            return weakness == Enums.SensorType.Thermal;
        }

        /// <summary>
        /// A method to reveal weaknesses of the agent based on the provided list of secret weaknesses.
        /// </summary>
        /// <param name="secretWeaknesses"></param>
        /// <returns></returns>
        public string? RevealWeakness(List<Enums.SensorType> secretWeaknesses)
        {
            if (_revealed || secretWeaknesses == null || secretWeaknesses.Count == 0)
                return null;

            _revealed = true;
            foreach (var weakness in secretWeaknesses)
            {
                if (weakness == Enums.SensorType.Thermal)
                    return weakness.ToString();
            }
            return null;
        }
    }
}