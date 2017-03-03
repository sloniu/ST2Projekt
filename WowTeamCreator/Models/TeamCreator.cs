using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WowTeamCreator.Models
{
    public class TeamCreator
    {
        public int Healers { get; set; } = 0;
        public int Tanks { get; set; } = 0;
        public int Dps { get; set; } = 0;
        public static readonly string[] PrefferedTeam = { "Healer", "Tank", "Dps", "Dps", "Dps" };
        

        public static TeamCreatorResult Create(List<Player> players)
        {
            var team = new List<Player>();
            players = players.Where(p => p.Selected).ToList();
            var missingRoles = new List<string>();
            foreach (var player in PrefferedTeam)
            {
                var chosenOne = players.FirstOrDefault(p => string.Equals(p.Role, player, StringComparison.InvariantCultureIgnoreCase));
                if (chosenOne != null)
                {
                    team.Add(chosenOne);
                    players.Remove(chosenOne);
                }
                else
                {
                    missingRoles.Add(player);
                }
            }
            return new TeamCreatorResult
            {
                MissingRoles = missingRoles,
                Team = team.AsEnumerable()
            };
        }

        
    }
}