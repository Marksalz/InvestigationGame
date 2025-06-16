using InvestigationGame.Interface;
using InvestigationGame.Factorys;
using InvestigationGame.Manager;
using InvestigationGame.Player;

namespace InvestigationGame
{
    class Program
    {
        static void Main()
        {
            var player = new PlayerProfile { Name = "Player1" };
            var agentFactory = new AgentFactory();
            var sensorFactory = new SensorFactory();
            const int NUM_AGENTS = 5;

            var agents = GenerateAgents(agentFactory, player, NUM_AGENTS);
            RunInvestigationLoop(agents, sensorFactory, player);
        }

        private static List<IAgent> GenerateAgents(IAgentFactory agentFactory, PlayerProfile player, int count)
        {
            // Only allow higher agent types if player has reached the required rank
            var enumAgentTypes = new List<Enums.AgentType>
            {
                Enums.AgentType.FootSoldier,
                Enums.AgentType.SquadLeader,
                Enums.AgentType.SeniorCommander,
                Enums.AgentType.OrganizationLeader
            };

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
                var weaknesses = new List<string>();
                for (int j = 0; j < weaknessCount; j++)
                {
                    weaknesses.Add(allSensorTypes[random.Next(allSensorTypes.Count)].ToString().ToLower());
                }
                agents.Add(agentFactory.CreateAgent(agentType, weaknesses));
            }
            return agents;
        }

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

        private static void DisplayAgentMenu(List<IAgent> agents, int currentAgentIndex)
        {
            Console.WriteLine("=== Agent Investigation Menu ===");
            for (int i = 0; i < agents.Count; i++)
            {
                string status = i < currentAgentIndex ? "[Investigated]" : (i == currentAgentIndex ? "[Available]" : "[Locked]");
                Console.WriteLine($"{i + 1}. {agents[i].Name} {status}");
            }
        }

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