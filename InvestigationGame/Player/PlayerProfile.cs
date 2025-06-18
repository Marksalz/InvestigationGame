using System;

namespace InvestigationGame.Player
{
    /// <summary>
    /// A class representing a player's profile in the game.
    /// </summary>
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