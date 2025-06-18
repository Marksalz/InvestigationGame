using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class SquadLeaderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<Enums.SensorType> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots { get; set; } = 4;

        public SquadLeaderAgent(string name, List<Enums.SensorType> weaknesses)
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
            return EvaluateSensors(sensors) == SensorSlots;
        }

        // add the toString method to provide a string representation of the agent
        public override string ToString()
        {
            return $"{Name} - Weaknesses: {string.Join(", ", SecretWeaknesses)}";
        }

        public List<ISensor> CounterAttack(List<ISensor> attachedSensors)
        {
            CounterAttackTurn++;
            if (CounterAttackTurn % 3 == 0 && attachedSensors.Count > 0)
            {
                var rand = new Random();
                int idx = rand.Next(attachedSensors.Count);
                string removedSensorName = attachedSensors[idx].Name;
                attachedSensors.RemoveAt(idx);
                Console.WriteLine($"Counterattack! The Sensor {removedSensorName} was removed by the Squad Leader.");
            }
            return attachedSensors;
        }
    }
}