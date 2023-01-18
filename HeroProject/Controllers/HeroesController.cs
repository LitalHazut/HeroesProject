﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HeroProject.Data;
using HeroProject.Models;
<<<<<<< HEAD
<<<<<<< Updated upstream
using System.Security.Claims;
using System;
using Serilog;
=======
using HeroProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Stashed changes
=======
>>>>>>> 08205252716ac39c862160cee19e9044eaf58ef2
using Microsoft.Graph;

namespace HeroProject.Controllers
{
    public class HeroesController : ApiController
    {
        private readonly IHeroRepository _heroRepository;
        public HeroesController(IHeroRepository heroRepository)
        {
            this._heroRepository = heroRepository;
        }

        //GET: api/Heroes/1       
<<<<<<< HEAD
<<<<<<< Updated upstream
        [Authorize(Roles = "read")]
=======
        //[Authorize(Roles = "read")]
>>>>>>> 08205252716ac39c862160cee19e9044eaf58ef2
        public List<Hero> GetByTrainerId(int trainerId)
        {  
            var allHeros = db.Heroes;
            var herosByTrainer = allHeros.Where(h => h.TrainerId == trainerId).AsEnumerable(); 
            return herosByTrainer.ToList();
=======
        public List<Hero> GetByTrainerId(int trainerId)
        {
            return _heroRepository.GetByTrainerId(trainerId);
>>>>>>> Stashed changes
        }

        // GET : api/Heroes/1
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> GetById(int heroId)
        {
            //Hero hero = db.Heroes.Where(h => h.HeroId == heroId).AsEnumerable().FirstOrDefault();
            var hero = _heroRepository.GetById(heroId);
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

            _heroRepository.CreateHeroForSpecificTrainer(hero);

            return CreatedAtRoute("DefaultApi", new { id = hero.HeroId }, hero);
        }

        //DELETE :api/Heroes/DeleteHero/1
        [ResponseType(typeof(Hero))]
        public async Task<IHttpActionResult> DeleteHero(int id)
        {
           var hero= _heroRepository.DeleteHero(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

    }


}