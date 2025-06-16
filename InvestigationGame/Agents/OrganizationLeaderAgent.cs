using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class OrganizationLeaderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<string> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots => 8;
        private readonly List<string> _originalWeaknesses;

        public OrganizationLeaderAgent(string name, List<string> weaknesses)
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
                attachedSensors.Clear();
                Console.WriteLine("Counterattack! All sensors were removed by the Organization Leader.");
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