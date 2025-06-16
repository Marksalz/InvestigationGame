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
        private int _turnCount = 0;

        public InvestigationManager(IAgent agent, ISensorFactory? sensorFactory = null)
        {
            _agent = agent;
            _sensorFactory = sensorFactory ?? new SensorFactory();
            _attachedSensors = new List<ISensor>();
        }

        public void StartInvestigation()
        {
            Console.WriteLine($"Investigation started against a {_agent.Name} agent.");

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nChoose a sensor to attach:");
                Console.WriteLine("1. Audio");
                Console.WriteLine("2. Thermal");
                Console.WriteLine("3. Motion");
                Console.WriteLine("4. Pulse");
                Console.WriteLine("5. Magnetic");
                Console.WriteLine("6. Signal");
                Console.WriteLine("7. Light");
                Console.Write("Your choice (1-7): ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int sensorChoice) || sensorChoice < 1 || sensorChoice > 7)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                Enums.SensorType sensorType = (Enums.SensorType)(sensorChoice - 1);

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
                Console.WriteLine();

                _turnCount++;

                // Counterattack logic
                if (_agent is ICounterAttackAgent counterAgent)
                {
                    counterAgent.CounterAttack(_attachedSensors);
                }

                if (_agent.IsExposed(_attachedSensors))
                {
                    Console.WriteLine("Agent exposed!");
                    Console.WriteLine("******************");
                    Console.WriteLine();
                    isRunning = false;
                }
            }
        }
    }
}