using HeroProject.Models;
using System.Data.Entity;
namespace HeroProject.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
    }
}
