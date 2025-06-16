using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class SeniorCommanderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<string> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots => 6;
        private readonly List<string> _originalWeaknesses;

        public SeniorCommanderAgent(string name, List<string> weaknesses)
        {
            Name = name;
            SecretWeaknesses = new List<string>(weaknesses);
            _originalWeaknesses = new List<string>(weaknesses);
        }

        public int EvaluateSensors(List<ISensor> sensors)
        {
            var tempWeaknesses = new List<string>(SecretWeaknesses);
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
            return EvaluateSensors(sensors) == SecretWeaknesses.Count;
        }

        public void CounterAttack(List<ISensor> attachedSensors)
        {
            CounterAttackTurn++;
            if (CounterAttackTurn % 3 == 0 && attachedSensors.Count > 0)
            {
                var rand = new Random();
                int removeCount = Math.Min(2, attachedSensors.Count);
                for (int i = 0; i < removeCount; i++)
                {
                    int idx = rand.Next(attachedSensors.Count);
                    attachedSensors.RemoveAt(idx);
                }
                Console.WriteLine("Counterattack! Two sensors were removed by the Senior Commander.");
            }
            if (CounterAttackTurn % 10 == 0)
            {
                SecretWeaknesses = new List<string>(_originalWeaknesses);
                attachedSensors.Clear();
                Console.WriteLine("Major counterattack! Weaknesses reset and all sensors removed.");
            }
        }
    }
}