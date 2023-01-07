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

        //GET: api/Heroes/idTrainer

        public List<Hero> GetHeroesForSpecificTrainer(int idTrainer)
        {
            var allHeros = db.Heroes;
            var herosByTrainer = allHeros.Where(h => h.TrainerId == idTrainer);
            return herosByTrainer.ToList();

        }

        // GET: api/Heroes/id
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> GetHeroData(int id)
        {
            Hero hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/Heroes/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> UpdateHeroData(int id, Hero hero)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != hero.HeroId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(hero).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HeroExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Heroes
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

        // DELETE: api/Heroes/id
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeroExists(int id)
        {
            return db.Heroes.Count(e => e.HeroId == id) > 0;
        }
    }
}