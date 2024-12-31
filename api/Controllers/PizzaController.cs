using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController:ControllerBase
    {
        private readonly PizzaContext _context;

        public PizzaController(PizzaContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> Get()
        {
           return Ok(await _context.Pizzas.ToListAsync());
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]

        public async Task<ActionResult> Post([FromBody]Pizza pizza)
        {
            _context.Pizzas.Add(pizza);

            await _context.SaveChangesAsync();

            return Ok();
        }


    }
    }
