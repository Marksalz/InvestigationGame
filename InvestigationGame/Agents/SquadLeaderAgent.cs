using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    /// <summary>
    /// A class representing a Squad Leader agent in the Investigation Game.
    /// </summary>
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
        /// A method to check if the agent is exposed based on the sensors attached.
        /// </summary>
        /// <param name="sensors"></param>
        /// <returns></returns>
        public bool IsExposed(List<ISensor> sensors)
        {
            return EvaluateSensors(sensors) == SensorSlots;
        }

        public override string ToString()
        {
            return $"{Name} - Weaknesses: {string.Join(", ", SecretWeaknesses)}";
        }

        /// <summary>
        /// A method to perform a counterattack against attached sensors.
        /// </summary>
        /// <param name="attachedSensors"></param>
        /// <returns></returns>
        public List<ISensor> CounterAttack(List<ISensor> attachedSensors)
        {
            CounterAttackTurn++;
            if (CounterAttackTurn % 3 == 0 && attachedSensors.Count > 0)
            {
                // Check for MagneticSensor cancel
                foreach (var sensor in attachedSensors)
                {
                    if (sensor is Sensors.MagneticSensor magneticSensor)
                    {
                        if (magneticSensor.TryCancelCounterAttack(Enums.SensorType.Magnetic))
                        {
                            Console.WriteLine("Counterattack was canceled by a Magnetic Sensor!");
                            return attachedSensors;
                        }
                    }
                }

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