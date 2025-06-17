using System;

namespace InvestigationGame.Player
{
    public class PlayerProfile
    {
        public string? Name { get; set; }
        public string HighestAgentRank { get; set; } = "Foot Soldier";

        public void UpdateRank(string newRank)
        {
            HighestAgentRank = newRank;
        }
    }
}