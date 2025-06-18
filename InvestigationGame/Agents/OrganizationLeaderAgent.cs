using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestigationGame.Agents
{
    /// <summary>
    /// A class representing a Squad Leader agent in the Investigation Game.
    /// </summary>
    public class OrganizationLeaderAgent : IAgent, ICounterAttackAgent
    {
        public string Name { get; set; }
        public List<Enums.SensorType> SecretWeaknesses { get; set; } = new();
        public int CounterAttackTurn { get; private set; } = 0;
        public int SensorSlots { get; set; } = 8;
        private readonly List<Enums.SensorType> _originalWeaknesses;

        public OrganizationLeaderAgent(string name, List<Enums.SensorType> weaknesses)
        {
            Name = name;
            SecretWeaknesses = new List<Enums.SensorType>(weaknesses);
            _originalWeaknesses = new List<Enums.SensorType>(weaknesses);
        }

        /// <summary>
        /// A method to evaluate the sensors attached to this agent.
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
        /// A method to check if the agent is exposed based on the attached sensors.
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

        /// <summary>
        /// A method to handle counterattacks against the attached sensors.
        /// </summary>
        /// <param name="attachedSensors"></param>
        /// <returns></returns>
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

            // Minor counterattack every 3 turns
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
                Console.WriteLine($"Counterattack! The sensor {removedSensorName} was removed by the Organization Leader.");
                return attachedSensors;
            }
            return attachedSensors;
        }
    }
}