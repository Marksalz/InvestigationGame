using InvestigationGame.Interface;
using System;
using System.Collections.Generic;
using InvestigationGame.Agents;
using InvestigationGame.Manager;

namespace InvestigationGame
{
    class Program
    {
        static void Main()
        {
            List<string> weaknesses = new List<string> { "thermal", "thermal" };
            IAgent agent = new BasicIranianAgent(weaknesses);
            InvestigationManager manager = new InvestigationManager(agent);
            manager.StartInvestigation();
        }
    }
}