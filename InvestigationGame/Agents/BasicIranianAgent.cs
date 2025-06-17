//using InvestigationGame.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace InvestigationGame.Agents
//{
//    public class BasicIranianAgent : IAgent
//    {
//        public string Name { get; set; }

//        public List<string> SecretWeaknesses { get; set; } = new List<string>();

//        public int TotalRequiredSensors => SecretWeaknesses.Count;


//        public BasicIranianAgent(string name, List<string> weaknesses)
//        {
//            Name = name;
//            SecretWeaknesses = new List<string>(weaknesses);
//        }

//        public int EvaluateSensors(List<ISensor> sensors)
//        {
//            var tempWeaknesses = new List<string>(SecretWeaknesses);
//            int matchCount = 0;

//            foreach (var sensor in sensors)
//            {
//                var match = tempWeaknesses.FirstOrDefault(w => sensor.Matches(w));
//                if (match != null)
//                {
//                    matchCount++;
//                    tempWeaknesses.Remove(match);
//                }
//            }

//            return matchCount;
//        }

//        public bool IsExposed(List<ISensor> sensors)
//        {
//            return EvaluateSensors(sensors) == SecretWeaknesses.Count;
//        }
//    }
//}