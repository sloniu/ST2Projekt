using WowTeamCreator.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WowTeamCreator.DAL
{
    public class WowContext : DbContext
    {
        public WowContext() : base("SchoolContext")
        {
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}