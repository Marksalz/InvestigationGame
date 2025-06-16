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
                "thermal" => new BasicSensor("thermal"),
                "motion" => new BasicSensor("motion"),
                "pulse" => new PulseSensor(),
                // Add new sensor types here
                _ => throw new ArgumentException($"Unknown sensor type: {type}")
            };
        }
    }
}