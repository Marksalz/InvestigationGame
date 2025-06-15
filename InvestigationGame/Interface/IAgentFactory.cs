using System.Collections.Generic;

namespace InvestigationGame.Interface
{
    public interface IAgentFactory
    {
        IAgent CreateAgent(string type, List<string> weaknesses);
    }
}