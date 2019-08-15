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
    public class DirectorController : ControllerBase
    {

        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {

            _directorService = directorService;

        }

        // GET Director by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_directorService.Select(id));
        }

        // GET List All
        [HttpGet]
        public IActionResult Getll()
        {

            return Ok(_directorService.SelectAll());

        }

        // POST new Director
        [HttpPost]
        public IActionResult Post([FromBody] Director director)
        {

            return Ok(_directorService.Add(director));

        }


        // PUT edit Director
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Director director)
        {

            return Ok(_directorService.Update(id, director));

        }

        // DELETE remove Director
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_directorService.Delete(id));

        }

    }
}