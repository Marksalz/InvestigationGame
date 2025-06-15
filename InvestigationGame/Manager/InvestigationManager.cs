using InvestigationGame.Interface;
using InvestigationGame.Sensors;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Manager
{
    public class InvestigationManager
    {
        private readonly IAgent _agent;
        private readonly List<ISensor> _attachedSensors;

        public InvestigationManager(IAgent agent)
        {
            _agent = agent;
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

                ISensor? sensor = input switch
                {
                    "1" => new BasicSensor("thermal"),
                    "2" => new BasicSensor("motion"),
                    _ => null
                };

                if (sensor == null)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                _attachedSensors.Add(sensor);

                int match = _agent.EvaluateSensors(_attachedSensors);
                int total = _agent.TotalRequiredSensors;

                Console.WriteLine($"Match result: {match}/{total}");

                if (_agent.IsExposed(_attachedSensors))
                {
                    Console.WriteLine("Agent exposed!");
                    break;
                }
            }
        }
    }
}