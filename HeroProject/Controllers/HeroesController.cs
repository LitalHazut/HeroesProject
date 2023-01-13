﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Data;
using HeroProject.Models;
using System.Security.Claims;
using System;

namespace HeroProject.Controllers
{
    public class HeroesController : ApiController
    {
        private Context db = new Context();


        //GET: api/Heroes/1       
        [Authorize(Roles = "read")]
        public List<Hero> GetByTrainerId( int trainerId)
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

        //public Object GetToken(string userId)
        //{
        //    var key = ConfigurationManager.AppSettings["JwtKey"];

        //    var issuer = ConfigurationManager.AppSettings["JwtIssuer"];

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    //Create a List of Claims, Keep claims name short    
        //    var permClaims = new List<Claim>();
        //    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //    permClaims.Add(new Claim("userid", "userId"));

        //    //Create Security Token object by giving required parameters    
        //    var token = new JwtSecurityToken(issuer, //Issure    
        //                    issuer,  //Audience    
        //                    permClaims,
        //                    expires: DateTime.Now.AddDays(1),
        //                    signingCredentials: credentials);
        //    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
        //    return new { data = jwt_token };
        //}

        [HttpPost]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        
        [HttpPost]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                return new
                {
                    data = name
                };

            }
            return null;
        }
    }


}