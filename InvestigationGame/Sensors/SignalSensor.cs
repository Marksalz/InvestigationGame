using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Sensors
{
    public class SignalSensor : ISensor
    {
        public string Name { get; } = "signal";
        private bool _revealed = false;

        public bool Matches(string weakness)
        {
            return Name.Equals(weakness, StringComparison.OrdinalIgnoreCase);
        }

        // Reveals one field of information about the agent (e.g., rank)
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