using InvestigationGame.Interface;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    /// <summary>
    /// A class representing a foot soldier agent in the investigation game.
    /// </summary>
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

        /// <summary>
        /// A method to evaluate the sensors against the agent's weaknesses.
        /// </summary>
        /// <param name="sensors"></param>
        /// <returns></returns>
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

        /// <summary>
        /// A method to check if the agent is exposed based on the sensors provided.
        /// </summary>
        /// <param name="sensors"></param>
        /// <returns></returns>
        public bool IsExposed(List<ISensor> sensors)
        {
            return EvaluateSensors(sensors) == SecretWeaknesses.Count;
        }

        /// <summary>
        /// A method to return a string representation of the agent.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} - Weaknesses: {string.Join(", ", SecretWeaknesses)}";
        }
    }
}