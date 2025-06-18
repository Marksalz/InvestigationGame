using InvestigationGame.Interface;
using InvestigationGame.Factories;
using InvestigationGame.Manager;
using InvestigationGame.Player;

namespace InvestigationGame
{
    /// <summary>
    /// Main entry point for the Investigation Game application.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Ask the player for their name
            Console.Write("Enter your name: ");
            string? playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Player1";
            }

            // Initialize player profile and factories
            var player = new PlayerProfile { Name = playerName };
            var agentFactory = new AgentFactory();
            var sensorFactory = new SensorFactory();
            const int NUM_AGENTS = 4;

            List<IAgent> agents = GenerateAgents(agentFactory, player, NUM_AGENTS);
            printGenaratedAgents(agents);
            RunInvestigationLoop(agents, sensorFactory, player);
        }

        /// <summary>
        /// A method to generate a list of agents based on the player's profile and the specified count.
        /// </summary>
        /// <param name="agentFactory"></param>
        /// <param name="player"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static List<IAgent> GenerateAgents(IAgentFactory agentFactory, PlayerProfile player, int count)
        {
            // Only allow higher agent types if player has reached the required rank
            List<Enums.AgentType> enumAgentTypes = new List<Enums.AgentType>
            {
                Enums.AgentType.FootSoldier,
                Enums.AgentType.SquadLeader,
                Enums.AgentType.SeniorCommander,
                Enums.AgentType.OrganizationLeader
            };

            List<Enums.SensorType> allSensorTypes = new List<Enums.SensorType>
            {
                Enums.SensorType.Audio,
                Enums.SensorType.Thermal,
                Enums.SensorType.Motion,
                Enums.SensorType.Pulse,
                Enums.SensorType.Magnetic,
                Enums.SensorType.Signal,
                Enums.SensorType.Light
            };

            List<IAgent> agents = new List<IAgent>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var agentType = enumAgentTypes[i % enumAgentTypes.Count];
                int weaknessCount = agentType switch
                {
                    Enums.AgentType.FootSoldier => 2,
                    Enums.AgentType.SquadLeader => 4,
                    Enums.AgentType.SeniorCommander => 6,
                    Enums.AgentType.OrganizationLeader => 8,
                    _ => 2
                };
                var weaknesses = new List<Enums.SensorType>();
                for (int j = 0; j < weaknessCount; j++)
                {
                    weaknesses.Add(allSensorTypes[random.Next(allSensorTypes.Count)]);
                }
                agents.Add(agentFactory.CreateAgent(agentType, weaknesses));
            }
            return agents;
        }

        /// <summary>
        /// A method to print the generated agents to the console.
        /// </summary>
        /// <param name="agents"></param>
        public static void printGenaratedAgents(List<IAgent> agents)
        {
            Console.WriteLine("=== Agents Generated ===");
            foreach (var agent in agents)
            {
                Console.WriteLine(agent.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// A method to run the investigation loop, allowing the player to investigate agents in order.
        /// </summary>
        /// <param name="agents"></param>
        /// <param name="sensorFactory"></param>
        /// <param name="player"></param>
        private static void RunInvestigationLoop(List<IAgent> agents, ISensorFactory sensorFactory, PlayerProfile player)
        {
            int currentAgentIndex = 0;
            while (currentAgentIndex < agents.Count)
            {
                DisplayAgentMenu(agents, currentAgentIndex);
                Console.WriteLine("0. Exit");
                Console.Write($"Select agent {currentAgentIndex + 1} to investigate or 0 to exit: ");
                var input = Console.ReadLine();

                if (input == "0")
                    break;

                if (int.TryParse(input, out int agentIndex) && agentIndex == currentAgentIndex + 1)
                {
                    InvestigateAgent(agents[currentAgentIndex], sensorFactory, player);
                    currentAgentIndex++;
                }
                else
                {
                    Console.WriteLine("Invalid selection. You must investigate agents in order.");
                }
            }
        }

        /// <summary>
        /// This method displays the agent investigation menu, showing the status of each agent.
        /// </summary>
        /// <param name="agents"></param>
        /// <param name="currentAgentIndex"></param>
        private static void DisplayAgentMenu(List<IAgent> agents, int currentAgentIndex)
        {
            Console.WriteLine("=== Agent Investigation Menu ===");
            for (int i = 0; i < agents.Count; i++)
            {
                string status = i < currentAgentIndex ? "[Investigated]" : (i == currentAgentIndex ? "[Available]" : "[Locked]");
                Console.WriteLine($"{i + 1}. {agents[i].Name} {status}");
            }
        }

        /// <summary>
        /// This method handles the investigation of a specific agent, 
        /// allowing the player to attach sensors and check if the agent is exposed 
        /// and update the player's rank accordingly.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="sensorFactory"></param>
        /// <param name="player"></param>
        private static void InvestigateAgent(IAgent agent, ISensorFactory sensorFactory, PlayerProfile player)
        {
            var manager = new InvestigationManager(agent, sensorFactory);
            manager.StartInvestigation();

            if (agent.IsExposed(manager.GetAttachedSensors()))
            {
                player.UpdateRank(agent.Name);
            }
        }
    }
}