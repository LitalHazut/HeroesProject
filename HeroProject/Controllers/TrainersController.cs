using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Data;
using HeroProject.Models;

namespace HeroProject.Controllers
{
    public class TrainersController : ApiController
    {
        private Context db = new Context();


        // POST : api/Trainers/CreateTrainer
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> CreateTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(trainer);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainer.TrainerId }, trainer);
        }

        // GET: api/Trainers/1
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
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

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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
        private bool TrainerExists(int id)
        {
            return db.Trainers.Count(e => e.TrainerId == id) > 0;
        }
    }
}