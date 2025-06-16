using InvestigationGame.Interface;
using InvestigationGame.Sensors;
using System;

namespace InvestigationGame.Factorys
{
    public class SensorFactory : ISensorFactory
    {
        public ISensor CreateSensor(Enums.SensorType type)
        {
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