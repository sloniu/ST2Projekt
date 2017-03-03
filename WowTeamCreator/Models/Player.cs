using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WowTeamCreator.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int level { get; set; }
    }
}