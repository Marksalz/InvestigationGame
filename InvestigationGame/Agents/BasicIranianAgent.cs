using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class BasicIranianAgent : IAgent
    {
        private readonly List<string> _secretWeaknesses;

        public int TotalRequiredSensors => _secretWeaknesses.Count;

        public BasicIranianAgent(List<string> weaknesses)
        {
            _secretWeaknesses = new List<string>(weaknesses);
        }

        public int EvaluateSensors(List<ISensor> sensors)
        {
            var tempWeaknesses = new List<string>(_secretWeaknesses);
            int matchCount = 0;

            foreach (var sensor in sensors)
            {
                var match = tempWeaknesses.FirstOrDefault(w => sensor.Matches(w));
                if (match != null)
                {
                    matchCount++;
                    tempWeaknesses.Remove(match);
                }
            }

            return matchCount;
        }

        public bool IsExposed(List<ISensor> sensors)
        {
            return EvaluateSensors(sensors) == _secretWeaknesses.Count;
        }
    }
}