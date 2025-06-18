using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    /// <summary>
    /// An interface for agents.
    /// </summary>
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