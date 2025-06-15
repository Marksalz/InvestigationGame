using InvestigationGame.Interface;
using InvestigationGame.Factorys;
using InvestigationGame.Manager;
using System;
using System.Collections.Generic;
using InvestigationGame.Agents;
using InvestigationGame.Sensors;

namespace InvestigationGame
{
    class Program
    {
        static void Main()
        {
            IAgentFactory agentFactory = new AgentFactory();
            ISensorFactory sensorFactory = new SensorFactory();

            // Generate 5 agents with random weaknesses using helper function
            var agents = GenerateRandomAgents(agentFactory, 5, new List<string> { "thermal", "motion" });

            while (true)
            {
                Console.WriteLine("=== Agent Investigation Menu ===");
                for (int i = 0; i < agents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Agent #{i + 1}");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Select an agent to investigate (1-5): ");
                var input = Console.ReadLine();

                if (input == "0")
                    break;

                if (int.TryParse(input, out int agentIndex) && agentIndex >= 1 && agentIndex <= agents.Count)
                {
                    var manager = new InvestigationManager(agents[agentIndex - 1], sensorFactory);
                    manager.StartInvestigation();
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }
        }

        // Helper function to generate a list of agents with random weaknesses
        private static List<IAgent> GenerateRandomAgents(IAgentFactory agentFactory, int count, List<string> sensorTypes)
        {
            var agents = new List<IAgent>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                List<string> weaknesses = new List<string>
                {
                    sensorTypes[random.Next(sensorTypes.Count)],
                    sensorTypes[random.Next(sensorTypes.Count)]
                };
                agents.Add(agentFactory.CreateAgent("basiciranian", weaknesses));
            }

            return agents;
        }
    }
}