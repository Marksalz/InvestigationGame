using InvestigationGame.Agents;
using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Factorys
{
    public class AgentFactory : IAgentFactory
    {
        public IAgent CreateAgent(string type, List<string> weaknesses)
        {
            return type.ToLower() switch
            {
                "basiciranian" => new BasicIranianAgent(weaknesses),
                // Add new agent types here
                _ => throw new ArgumentException($"Unknown agent type: {type}")
            };
        }
    }
}