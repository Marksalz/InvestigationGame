using InvestigationGame.Interface;
using InvestigationGame.Sensors;
using System;

namespace InvestigationGame.Factories
{
    public class SensorFactory : ISensorFactory
    {
        /// <summary>
        /// This factory method creates a sensor based on the specified type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ISensor CreateSensor(Enums.SensorType type)
        {
            // This method uses a switch expression to determine which sensor to create based on the provided type.
            return type switch
            {
                Enums.SensorType.Audio => new AudioSensor(),
                Enums.SensorType.Thermal => new ThermalSensor(),
                Enums.SensorType.Motion => new MotionSensor(),
                Enums.SensorType.Pulse => new PulseSensor(),
                Enums.SensorType.Magnetic => new MagneticSensor(),
                Enums.SensorType.Signal => new SignalSensor(),
                Enums.SensorType.Light => new LightSensor(),
                _ => throw new ArgumentException($"Unknown sensor type: {type}")
            };
        }
    }
}