using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    public class SquadLeaderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<string> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots => 4;

        public SquadLeaderAgent(string name, List<string> weaknesses)
        {
            Name = name;
            SecretWeaknesses = new List<string>(weaknesses);
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
                int idx = rand.Next(attachedSensors.Count);
                attachedSensors.RemoveAt(idx);
                Console.WriteLine("Counterattack! A sensor was removed by the Squad Leader.");
            }
        }
    }
}