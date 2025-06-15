using InvestigationGame.Interface;
using InvestigationGame.Factorys;
using InvestigationGame.Sensors;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Manager
{
    public class InvestigationManager
    {
            private readonly ISensorFactory _sensorFactory;
        private readonly IAgent _agent;
        private readonly List<ISensor> _attachedSensors;

        // Accept agent instance directly
        public InvestigationManager(IAgent agent, ISensorFactory? sensorFactory = null)
        {
            _agent = agent;
            _sensorFactory = sensorFactory ?? new SensorFactory();
            _attachedSensors = new List<ISensor>();
        }

        public void StartInvestigation()
        {
            Console.WriteLine("Investigation started against a low-level Iranian agent.");

            while (true)
            {
                Console.WriteLine("\nChoose a sensor to attach:");
                Console.WriteLine("1. Thermal");
                Console.WriteLine("2. Motion");
                Console.Write("Your choice (1/2): ");
                var input = Console.ReadLine();

                string? sensorType = input switch
                {
                    "1" => "thermal",
                    "2" => "motion",
                    _ => null
                };

                if (sensorType == null)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                ISensor sensor;
                try
                {
                    sensor = _sensorFactory.CreateSensor(sensorType);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                _attachedSensors.Add(sensor);

                int match = _agent.EvaluateSensors(_attachedSensors);
                int total = _agent.SecretWeaknesses.Count;

                Console.WriteLine($"Match result: {match}/{total}");

                if (_agent.IsExposed(_attachedSensors))
                {
                    Console.WriteLine("Agent exposed!");
                    Console.WriteLine("******************");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}