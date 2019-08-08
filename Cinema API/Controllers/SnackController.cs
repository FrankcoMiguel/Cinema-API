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
    public class SnackController : ControllerBase
    {

        private readonly ISnackService _snackService;

        public SnackController(ISnackService snackService)
        {

            _snackService = snackService;

        }

        // GET Snack by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_snackService.Select(id));
        }

        // GET List All
        [HttpGet]
        public IActionResult Getll()
        {

            return Ok(_snackService.SelectAll());

        }

        // POST new Snack
        [HttpPost]
        public IActionResult Post([FromBody] Snack snack)
        {

            return Ok(_snackService.Add(snack));

        }


        // PUT edit Snack
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Snack snack)
        {

            return Ok(_snackService.Update(id, snack));

        }

        // DELETE remove Snack
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_snackService.Delete(id));

        }

    }
}