using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WowTeamCreator.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Level { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
    }
}