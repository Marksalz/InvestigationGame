using InvestigationGame.Interface;
using InvestigationGame.Factorys;
using InvestigationGame.Manager;
using System;
using System.Collections.Generic;
using InvestigationGame.Agents;
using InvestigationGame.Sensors;
using InvestigationGame.Player;

namespace InvestigationGame
{
    class Program
    {
        static void Main()
        {
            PlayerProfile player = new PlayerProfile { Name = "Player1" };

            IAgentFactory agentFactory = new AgentFactory();
            ISensorFactory sensorFactory = new SensorFactory();
            const int NUM_AGENTS = 5;

            // Only allow Squad Leader if player has defeated Basic Iranian
            List<string> availableAgentTypes = new() { "basiciranian" };
            if (player.HighestAgentRank == "Squad Leader")
                availableAgentTypes.Add("squadleader");

            // Use all sensor types for weaknesses
            var allSensorTypes = new List<Enums.SensorType>
            {
                Enums.SensorType.Audio,
                Enums.SensorType.Thermal,
                Enums.SensorType.Motion,
                Enums.SensorType.Pulse,
                Enums.SensorType.Magnetic,
                Enums.SensorType.Signal,
                Enums.SensorType.Light
            };

            List<IAgent> agents = GenerateRandomAgents(agentFactory, NUM_AGENTS, allSensorTypes, availableAgentTypes);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("=== Agent Investigation Menu ===");
                for (int i = 0; i < agents.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {agents[i].Name}");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Select an agent to investigate (1-{0}): ", agents.Count);
                var input = Console.ReadLine();

                if (input == "0")
                    break;

                if (int.TryParse(input, out int agentIndex) && agentIndex >= 1 && agentIndex <= agents.Count)
                {
                    InvestigationManager manager = new InvestigationManager(agents[agentIndex - 1], sensorFactory);
                    manager.StartInvestigation();

                    // If agent is exposed, update player profile
                    if (agents[agentIndex - 1].IsExposed(new List<ISensor>()))
                    {
                        player.UpdateRank(agents[agentIndex - 1].Name);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }
            }
        }

        private static List<IAgent> GenerateRandomAgents(IAgentFactory agentFactory, int count, List<Enums.SensorType> sensorTypes, List<string> agentTypes)
        {
            var agents = new List<IAgent>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                string agentType = agentTypes[random.Next(agentTypes.Count)];
                int weaknessCount = agentType == "squadleader" ? 4 : 2;
                List<string> weaknesses = new();
                for (int j = 0; j < weaknessCount; j++)
                {
                    // Store as string for compatibility with existing agent constructors
                    weaknesses.Add(sensorTypes[random.Next(sensorTypes.Count)].ToString().ToLower());
                }
                agents.Add(agentFactory.CreateAgent(agentType, weaknesses));
            }

            return agents;
        }
    }
}