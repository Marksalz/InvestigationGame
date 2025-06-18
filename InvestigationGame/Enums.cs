using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    /// <summary>
    /// A collection of enumerations used throughout the Investigation Game project.
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Types of sensors that can be used in the game.
        /// </summary>
        public enum SensorType
        {
            Audio,
            Thermal,
            Motion,
            Pulse,
            Magnetic,
            Signal,
            Light
        }

        /// <summary>
        /// Types of agents that can be deployed in the game.
        /// </summary>
        public enum AgentType
        {
            FootSoldier,
            SquadLeader,
            SeniorCommander,
            OrganizationLeader
        }
    }
}
