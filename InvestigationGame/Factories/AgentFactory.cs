using InvestigationGame.Agents;
using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Factories
{
    public class AgentFactory : IAgentFactory
    {
        //public IAgent CreateAgent(string type, List<string> weaknesses)
        //{
        //    return CreateAgent(Enum.TryParse<Enums.AgentType>(type, true, out var agentType) ? agentType : throw new ArgumentException($"Unknown agent type: {type}"), weaknesses);
        //}

        public IAgent CreateAgent(Enums.AgentType type, List<Enums.SensorType> weaknesses)
        {
            return type switch
            {
                Enums.AgentType.FootSoldier => new FootSoldierAgent("Foot Soldier", weaknesses),
                Enums.AgentType.SquadLeader => new SquadLeaderAgent("Squad Leader", weaknesses),
                Enums.AgentType.SeniorCommander => new SeniorCommanderAgent("Senior Commander", weaknesses),
                Enums.AgentType.OrganizationLeader => new OrganizationLeaderAgent("Organization Leader", weaknesses),
                _ => throw new ArgumentException($"Unknown agent type: {type}")
            };
        }
    }
}