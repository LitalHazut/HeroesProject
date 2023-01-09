using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Data;
using HeroProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;

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

        [HttpGet]
        public Object GetToken()
        {
            string key = "my_secret_key_12345"; //Secret key which will be used later during validation    
            var issuer = "http://mysite.com";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }

    }
}