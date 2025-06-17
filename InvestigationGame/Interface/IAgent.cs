using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface IAgent
    {
        string Name { get; set; }
        List<Enums.SensorType> SecretWeaknesses { get; set; }
        int SensorSlots { get; set; } 
        int EvaluateSensors(List<ISensor> sensors);
        bool IsExposed(List<ISensor> sensors);
        string ToString();
    }
}