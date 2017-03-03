using System.Collections.Generic;

namespace WowTeamCreator.Models
{
    public class TeamCreatorResult
    {
        public IEnumerable<Player> Team { get; set; }
        public List<string> MissingRoles { get; set; }
    }
}