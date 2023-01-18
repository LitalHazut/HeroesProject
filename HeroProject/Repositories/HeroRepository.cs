using HeroProject.Data;
using HeroProject.Models;
using HeroProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HeroProject.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly Context db;
        public HeroRepository(Context context)
        {
            db = context;
        }
        public List<Hero> GetByTrainerId(int trainerId)
        {
            var allHeros = db.Heroes;
            var herosByTrainer =  allHeros.Where(h => h.TrainerId == trainerId).AsEnumerable();
            return herosByTrainer.ToList();
        }
        public Hero GetById(int heroId)
        {
            Hero hero = db.Heroes.Where(h => h.HeroId == heroId).AsEnumerable().FirstOrDefault();
            return hero;
        }
        public void CreateHeroForSpecificTrainer(Hero hero)
        {
             db.Heroes.Add(hero);
             db.SaveChangesAsync();
        }
        public Hero DeleteHero(int id)
        {
            var hero = GetById(id);
            if (hero == null) return null;
            db.Heroes.Remove(hero);
            db.SaveChanges();
            return hero;
        }

       
    }
}