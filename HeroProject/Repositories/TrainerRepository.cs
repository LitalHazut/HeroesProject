using HeroProject.Data;
using HeroProject.Models;
using HeroProject.Repositories.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace HeroProject.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly Context db;
        public TrainerRepository(Context context)
        {
            db = context;
        }
        public void CreateTrainer(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            db.SaveChangesAsync();
        }
        public Trainer GetById(int id)
        {
            Trainer trainer = db.Trainers.Where(h => h.TrainerId == id).AsEnumerable().FirstOrDefault();
            return trainer;
        }

        public void UpdateTrainerData(int id, Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
        }
        public bool TrainerExists(int id)
        {
            return db.Trainers.Count(e => e.TrainerId == id) > 0;
        }
        public void SaveChanges()
        {
            db.SaveChangesAsync();
        }
    }
}