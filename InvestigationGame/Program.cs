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
            var weaknesses = new List<string> { "thermal", "thermal" };
            IAgent agent = new BasicIranianAgent(weaknesses);
            var manager = new InvestigationManager(agent);
            manager.StartInvestigation();
        }
    }
}