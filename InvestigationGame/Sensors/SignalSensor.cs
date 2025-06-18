using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a thermal sensor in the Investigation Game.
    /// </summary>
    public class SignalSensor : ISensor
    {
        public string Name { get; } = "signal";
        private bool _revealed = false;

        /// <summary>
        /// A method to check if the sensor matches a specific weakness type.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            return weakness == InvestigationGame.Enums.SensorType.Signal;
        }

        /// <summary>
        /// A method to reveal information about the agent, according to the sensor's capabilities.
        /// </summary>
        /// <param name="agentInfo"></param>
        /// <returns></returns>
        public string? RevealInfo(Dictionary<string, string> agentInfo)
        {
            if (_revealed || agentInfo == null || agentInfo.Count == 0)
                return null;

            _revealed = true;
            // Reveal the first available field for demonstration
            foreach (var kvp in agentInfo)
            {
                return $"{kvp.Key}: {kvp.Value}";
            }
            return null;
        }
    }
}