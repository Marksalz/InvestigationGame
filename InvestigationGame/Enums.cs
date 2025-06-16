using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    public class Enums
    {
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

        public enum AgentType
        {
            FootSoldier,
            SquadLeader,
            SeniorCommander,
            OrganizationLeader
        }
    }
}
