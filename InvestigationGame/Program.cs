using System;
using System.Collections.Generic;

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