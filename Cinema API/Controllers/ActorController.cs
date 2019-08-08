using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {

        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {

            _actorService = actorService;

        }

        // GET Actor by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_actorService.Select(id));
        }

        // GET List All
        [HttpGet]
        public IActionResult Getll()
        {

            return Ok(_actorService.SelectAll());

        }

        // POST new Actor
        [HttpPost]
        public IActionResult Post([FromBody] Actor Actor)
        {

            return Ok(_actorService.Add(Actor));

        }


        // PUT edit Actor
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Actor Actor)
        {

            return Ok(_actorService.Update(id, Actor));

        }

        // DELETE remove Actor
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_actorService.Delete(id));

        }

    }
}