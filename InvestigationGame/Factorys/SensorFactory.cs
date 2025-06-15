using InvestigationGame.Interface;
using InvestigationGame.Sensors;

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
                _ => throw new ArgumentException($"Unknown sensor type: {type}")
            };
        }
    }
}