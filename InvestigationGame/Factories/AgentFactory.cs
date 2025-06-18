using InvestigationGame.Agents;
using InvestigationGame.Interface;
using System;
using System.Collections.Generic;

namespace InvestigationGame.Factories
{
    /// <summary>
    /// A factory class for creating agents of different types with specific weaknesses.
    /// </summary>
    public class AgentFactory : IAgentFactory
    {
        public IAgent CreateAgent(Enums.AgentType type, List<Enums.SensorType> weaknesses)
        {
            // This method creates an agent based on the specified type and weaknesses.
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