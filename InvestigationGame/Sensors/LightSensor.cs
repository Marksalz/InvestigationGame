using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Sensors
{
    public class LightSensor : ISensor
    {
        public string Name { get; } = "light";
        private bool _revealed = false;

        public bool Matches(InvestigationGame.Enums.SensorType weakness)
        {
            return weakness == InvestigationGame.Enums.SensorType.Light;
        }

        // Reveals two fields of information about the agent (e.g., affiliation)
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