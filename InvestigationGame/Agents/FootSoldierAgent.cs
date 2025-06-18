using InvestigationGame.Interface;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class FootSoldierAgent : IAgent
    {
        public string Name { get; set; }
        public List<Enums.SensorType> SecretWeaknesses { get; set; } = new();
        public int SensorSlots { get; set; } = 2;

        public FootSoldierAgent(string name, List<Enums.SensorType> weaknesses)
        {
            Name = name;
            SecretWeaknesses = new List<Enums.SensorType>(weaknesses);
        }

        public int EvaluateSensors(List<ISensor> sensors)
        {
            var tempWeaknesses = new List<Enums.SensorType>(SecretWeaknesses);
            int matchCount = 0;
            foreach (var sensor in sensors)
            {
                int idx = tempWeaknesses.FindIndex(w => sensor.Matches(w));
                if (idx != -1)
                {
                    matchCount++;
                    tempWeaknesses.RemoveAt(idx);
                }
            }
            return matchCount;
        }

        public bool IsExposed(List<ISensor> sensors)
        {
            return EvaluateSensors(sensors) == SecretWeaknesses.Count;
        }

        public override string ToString()
        {
            return $"{Name} - Weaknesses: {string.Join(", ", SecretWeaknesses)}";
        }
    }
}