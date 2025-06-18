using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Sensors
{
    /// <summary>
    /// A class representing a light sensor in the Investigation Game.
    /// </summary>
    public class LightSensor : ISensor
    {
        public string Name { get; } = "light";
        private bool _revealed = false;

        /// <summary>
        /// A method to check if the sensor matches a specific weakness type.
        /// </summary>
        /// <param name="weakness"></param>
        /// <returns></returns>
        public bool Matches(Enums.SensorType weakness)
        {
            return weakness == Enums.SensorType.Light;
        }

        /// <summary>
        /// A method to reveal information about agents based on the provided agent info.
        /// </summary>
        /// <param name="agentInfo"></param>
        /// <returns></returns>
        public List<string>? RevealInfo(Dictionary<string, string> agentInfo)
        {
            if (_revealed || agentInfo == null || agentInfo.Count == 0)
                return null;

            _revealed = true;
            // Reveal the first two available fields for demonstration
            return agentInfo.Take(2).Select(kvp => $"{kvp.Key}: {kvp.Value}").ToList();
        }
    }
}