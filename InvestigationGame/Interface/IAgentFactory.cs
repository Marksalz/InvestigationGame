using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface IAgentFactory
    {
        IAgent CreateAgent(string type, List<string> weaknesses);
        IAgent CreateAgent(Enums.AgentType type, List<string> weaknesses);
    }
}