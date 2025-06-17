using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class SeniorCommanderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<Enums.SensorType> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots { get; set; } = 6;
        private readonly List<Enums.SensorType> _originalWeaknesses;

        public SeniorCommanderAgent(string name, List<Enums.SensorType> weaknesses)
        {
            Name = name;
            SecretWeaknesses = new List<Enums.SensorType>(weaknesses);
            _originalWeaknesses = new List<Enums.SensorType>(weaknesses);
        }

        public int EvaluateSensors(List<ISensor> sensors)
        {
            var tempWeaknesses = new List<Enums.SensorType>(SecretWeaknesses);
            int matchCount = 0;
            foreach (var sensor in sensors)
            {
                var match = tempWeaknesses.FirstOrDefault(w => sensor.Matches(w));
                if (match != 0)
                {
                    matchCount++;
                    tempWeaknesses.Remove(match);
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

        public List<ISensor> CounterAttack(List<ISensor> attachedSensors)
        {
            CounterAttackTurn++;
            // Major counterattack takes precedence
            if (CounterAttackTurn % 10 == 0)
            {
                SecretWeaknesses = new List<Enums.SensorType>(_originalWeaknesses);
                attachedSensors.Clear();
                Console.WriteLine("Major counterattack! Weaknesses reset and all sensors removed.");
                return attachedSensors;
            }
            if (CounterAttackTurn % 3 == 0 && attachedSensors.Count > 0)
            {
                var rand = new Random();
                int removeCount = Math.Min(2, attachedSensors.Count);
                List<string> removedSensors = new List<string>();
                for (int i = 0; i < removeCount; i++)
                {
                    int idx = rand.Next(attachedSensors.Count);
                    removedSensors.Add(attachedSensors[idx].Name);
                    attachedSensors.RemoveAt(idx);
                }
                Console.WriteLine($"Counterattack! The following sensors were removed by the Senior Commander: {string.Join(", ", removedSensors)}.");
                return attachedSensors;
            }
            return attachedSensors;
        }
    }
}