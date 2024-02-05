using Microsoft.AspNetCore.Mvc;
using PayLess.Data;
using PayLess.Models;

namespace PayLess.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LojasController : Controller
    {
        [HttpGet("lojas")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Lojas.ToList());
        }
        
        [HttpGet("lojas/{id:int}")]
        public IActionResult GetById([FromRoute]int id,[FromServices] AppDbContext context)
        {
            var loja = context.Lojas.FirstOrDefault(x => x.Id == id);

            if (loja == null)
            {
                return NotFound();
            }
            return Ok(loja);
        }

        [HttpPost("lojas")]
        public IActionResult Post([FromBody] Loja loja,[FromServices] AppDbContext context)
        {
            context.Lojas.Add(loja);
            context.SaveChanges();
            return Created($"v1/lojas/{loja.Id}", loja);
        }

        [HttpPut("lojas/{id:int}")]
        public IActionResult Put(
            [FromRoute]int id,
            [FromBody] Loja loja, 
            [FromServices] AppDbContext context)
        {

            var oldLoja = context.Lojas.FirstOrDefault(x => x.Id == id);

            if (oldLoja == null)
            {
                return NotFound();
            }
            oldLoja.Nome = loja.Nome;
            oldLoja.Endereço = loja.Endereço;
            context.Lojas.Update(oldLoja);
            context.SaveChanges();

            return Ok(loja);
        }

        [HttpDelete("lojas/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var loja = context.Lojas.FirstOrDefault(x => x.Id == id);

            if (loja == null)
            {
                return NotFound();
            }

            context.Lojas.Remove(loja);
            context.SaveChanges();
            return Ok(loja);
        }
    }
}
