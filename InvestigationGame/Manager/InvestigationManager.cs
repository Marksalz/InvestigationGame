using InvestigationGame.Factories;
using InvestigationGame.Interface;
using InvestigationGame.Sensors;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace InvestigationGame.Manager
{
    public class InvestigationManager
    {
        private readonly ISensorFactory _sensorFactory;
        private readonly IAgent _agent;
        private List<ISensor> _attachedSensors;
        private int _turnCount = 0;

        public InvestigationManager(IAgent agent, ISensorFactory? sensorFactory = null)
        {
            _agent = agent ?? throw new ArgumentNullException(nameof(agent));
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

                // if the sensor is a MotionSensor or PulseSensor, activate it
                if (sensor is ISensorBroken brokenSensor && checkSensorBroken(brokenSensor))
                {
                    //  If the sensor is broken, skip adding it
                    Console.WriteLine($"The {sensor.Name} sensor is broken and cannot be attached.");
                    continue;
                }

                _attachedSensors.Add(sensor);
                ActivateRevel(sensor);

                if (_agent is ICounterAttackAgent counterAgent)
                {
                    _attachedSensors = counterAgent.CounterAttack(_attachedSensors);
                }

                int match = _agent.EvaluateSensors(_attachedSensors);
                int total = _agent.SensorSlots;

                //// Check for broken sensors and remove them
                //var brokenSensors = new List<ISensor>();
                //foreach (var sensor1 in _attachedSensors)
                //{
                //    // Only check for sensors that can break
                //    if ((sensor1 is MotionSensor motion && motion.IsBroken) ||
                //        (sensor1 is PulseSensor pulse && pulse.IsBroken))
                //    {
                //        Console.WriteLine($"The {sensor1.Name} sensor is broken and has been removed.");
                //        brokenSensors.Add(sensor1);
                //    }
                //}
                //foreach (var broken in brokenSensors)
                //{
                //    _attachedSensors.Remove(broken);
                //}

                // Display the current state of attached sensors
                Console.WriteLine("\nCurrent attached sensors:");
                foreach (var attachedSensor in _attachedSensors)
                {
                    Console.WriteLine($"- {attachedSensor.Name}");
                }
                Console.WriteLine($"Match result: {match}/{total}");
                Console.WriteLine();

                _turnCount++;

                if (_agent.IsExposed(_attachedSensors))
                {
                    Console.WriteLine("Agent exposed!");
                    Console.WriteLine("******************");
                    Console.WriteLine();

                    // reset all of sensors that can break
                    foreach (var attachedSensor in _attachedSensors)
                    {
                        if (attachedSensor is ISensorBroken brokenSensor1)
                        {
                            brokenSensor1.ResetActivation();
                        }
                    }
                    isRunning = false;
                }
            }
        }

        public bool checkSensorBroken(ISensorBroken sensor)
        {
           sensor.Activate();
           return sensor.IsBroken;
        }

        public void ActivateRevel(ISensor sensor)
        {
            var agentInfo = new Dictionary<string, string>
            {
                { "Name", _agent.Name },
                { "Weaknesses", string.Join(", ", _agent.SecretWeaknesses) },
                { "SensorSlots", _agent.SensorSlots.ToString() }
            };

            switch (sensor)
            {
                case ThermalSensor thermalSensor:               
                    var revealedWeakness = thermalSensor.RevealWeakness(_agent.SecretWeaknesses);
                    if (revealedWeakness != null)
                    {
                        Console.WriteLine($"[ThermalSensor] Revealed a weakness: {revealedWeakness}");
                    }
                    else
                    {
                        Console.WriteLine("[ThermalSensor] No weaknesses revealed.");
                    }
                    break;
                case SignalSensor signalSensor:
                    var revealedInfo = signalSensor.RevealInfo(agentInfo);
                    if (revealedInfo != null)
                    {
                        Console.WriteLine($"[SignalSensor] Revealed info: {revealedInfo}");
                    }
                    else
                    {
                        Console.WriteLine("[SignalSensor] No info revealed.");
                    }
                    break;
                case LightSensor lightSensor:
                    var revealedFields = lightSensor.RevealInfo(agentInfo);
                    if (revealedFields != null && revealedFields.Count > 0)
                    {
                        Console.WriteLine("[LightSensor] Revealed info:");
                        foreach (var field in revealedFields)
                        {
                            Console.WriteLine($"  {field}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[LightSensor] No info revealed.");
                    }
                    break;
                default:
                    // For other sensors, no special reveal logic is defined
                    Console.WriteLine($"[{sensor.Name}] No special reveal ability defined.");
                    break;
            }
        }

        public List<ISensor> GetAttachedSensors()
        {
            // Expose attached sensors for result checking in Program.cs
            return new List<ISensor>(_attachedSensors);
        }
    }
}