using HeroProject.Models;

namespace HeroProject.Repositories.Interfaces
{
    public interface ITrainerRepository
    {
        void CreateTrainer(Trainer trainer);
        Trainer GetById(int id);
        void UpdateTrainerData(int id, Trainer trainer);
        bool TrainerExists(int id);
        void SaveChanges();
    }
}
