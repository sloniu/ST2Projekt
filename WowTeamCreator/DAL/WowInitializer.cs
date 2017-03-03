﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WowTeamCreator.Models;

namespace WowTeamCreator.DAL
{
    public class WowInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WowContext>
    {
        protected override void Seed(WowContext context)
        {
            var players = new List<Player>
            {
                new Player { level = 5, name = "Anton", role = "Healer" },
            };

            players.ForEach(s => context.Players.Add(s));
            context.SaveChanges();
        }
    }
}