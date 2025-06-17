using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface IAgentFactory
    {
        IAgent CreateAgent(Enums.AgentType type, List<Enums.SensorType> weaknesses);
    }
}