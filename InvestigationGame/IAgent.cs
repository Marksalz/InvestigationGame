using System.Collections.Generic;

namespace InvestigationGame
{
    public interface IAgent
    {
        int TotalRequiredSensors { get; }
        int EvaluateSensors(List<ISensor> sensors);
        bool IsExposed(List<ISensor> sensors);
    }
}