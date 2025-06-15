using InvestigationGame.Interface;
using InvestigationGame.Factorys;
using System;
using System.Collections.Generic;
using InvestigationGame.Agents;
using InvestigationGame.Manager;
using InvestigationGame.Sensors;

namespace InvestigationGame
{
    class Program
    {
        static void Main()
        {
            IAgentFactory agentFactory = new AgentFactory();
            ISensorFactory sensorFactory = new SensorFactory();
            InvestigationManager manager = new InvestigationManager(agentFactory, sensorFactory);
            manager.StartInvestigation();
        }
    }
}