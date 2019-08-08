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
    public class FilmController : ControllerBase
    {

        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {

            _filmService = filmService;

        }

        // GET Film by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_filmService.Select(id));
        }

        // GET List All
        [HttpGet]
        public IActionResult Getll()
        {

            return Ok(_filmService.SelectAll());

        }

        // POST new Film
        [HttpPost]
        public IActionResult Post([FromBody] Film film)
        {

            return Ok(_filmService.Add(film));

        }


        // PUT edit Film
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Film film)
        {

            return Ok(_filmService.Update(id, film));

        }

        // DELETE remove Film
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_filmService.Delete(id));

        }

    }
}
