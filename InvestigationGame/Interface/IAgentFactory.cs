using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    /// <summary>
    /// A factory interface for creating agents of different types with specific weaknesses.
    /// </summary>
    public interface IAgentFactory
    {
        IAgent CreateAgent(Enums.AgentType type, List<Enums.SensorType> weaknesses);
    }
}