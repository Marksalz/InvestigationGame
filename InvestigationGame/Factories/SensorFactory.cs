using InvestigationGame.Interface;
using InvestigationGame.Sensors;
using System;

namespace InvestigationGame.Factorys
{
    public class SensorFactory : ISensorFactory
    {
        public ISensor CreateSensor(string type)
        {
            return type.ToLower() switch
            {
                "audio" => new AudioSensor(),
                "thermal" => new ThermalSensor(),
                "motion" => new MotionSensor(),
                "pulse" => new PulseSensor(),
                "magnetic" => new MagneticSensor(),
                "signal" => new SignalSensor(),
                "light" => new LightSensor(),
                _ => throw new ArgumentException($"Unknown sensor type: {type}")
            };
        }
    }
}