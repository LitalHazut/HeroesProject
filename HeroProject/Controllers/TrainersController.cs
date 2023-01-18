using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Models;
using HeroProject.Repositories.Interfaces;

namespace HeroProject.Controllers
{
    public class TrainersController : ApiController
    {
        private readonly ITrainerRepository _trainerRepository;
        public TrainersController(ITrainerRepository trainerRepository)
        {
            this._trainerRepository = trainerRepository;
        }

        // POST : api/Trainers/CreateTrainer
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> CreateTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _trainerRepository.CreateTrainer(trainer);

            return CreatedAtRoute("DefaultApi", new { id = trainer.TrainerId }, trainer);
        }

        // GET: api/Trainers/1
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Trainer trainer = _trainerRepository.GetById(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateTrainerData(int id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainer.TrainerId)
            {
                return BadRequest();
            }

            _trainerRepository.UpdateTrainerData(id, trainer);
            try
            {
                _trainerRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_trainerRepository.TrainerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}