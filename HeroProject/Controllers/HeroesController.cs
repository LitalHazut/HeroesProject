using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Data;
using HeroProject.Models;

namespace HeroProject.Controllers
{
    public class HeroesController : ApiController
    {
        private Context db = new Context();

        //GET: api/Heroes/1

        public List<Hero> GetByTrainerId(int trainerId)
        {
            var allHeros = db.Heroes;
            var herosByTrainer = allHeros.Where(h => h.TrainerId == trainerId).AsEnumerable();
            
            return herosByTrainer.ToList();

        }

        // GET : api/Heroes/1
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> GetById(int heroId)
        {
            Hero hero = db.Heroes.Where(h => h.HeroId == heroId).AsEnumerable().FirstOrDefault();

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // POST : api/Heroes/CreateHeroForSpecificTrainer
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> CreateHeroForSpecificTrainer(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Heroes.Add(hero);
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hero.HeroId }, hero);
        }

        //DELETE :api/Heroes/DeleteHero/1
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> DeleteHero(int id)
        {
            Hero hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            db.Heroes.Remove(hero);
            await db.SaveChangesAsync();

            return Ok(hero);
        }

    }
}