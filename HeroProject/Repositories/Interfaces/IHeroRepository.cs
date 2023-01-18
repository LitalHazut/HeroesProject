using HeroProject.Models;
using System.Collections.Generic;

namespace HeroProject.Repositories.Interfaces
{
    public interface IHeroRepository
    {
        List<Hero> GetByTrainerId(int trainerId);
        Hero GetById (int heroId);
        void CreateHeroForSpecificTrainer(Hero hero);
        Hero DeleteHero(int id);

    }
}
