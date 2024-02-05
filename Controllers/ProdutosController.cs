using Microsoft.AspNetCore.Mvc;
using PayLess.Data;
using PayLess.Models;

namespace PayLess.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutosController : Controller
    {
        [HttpGet("produtos")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Produtos.ToList());
        }

        [HttpGet("produtos/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost("produtos")]
        public IActionResult Post([FromBody] Produto produto, [FromServices] AppDbContext context)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
            return Created($"v1/produtos/{produto.Id}", produto);
        }

        [HttpPut("produtos/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] Produto produto,
            [FromServices] AppDbContext context)
        {

            var oldProduto = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (oldProduto == null)
            {
                return NotFound();
            }

            oldProduto.Nome = produto.Nome;
            oldProduto.Preco = produto.Preco;
            oldProduto.Estoque = produto.Estoque;

            context.Produtos.Update(oldProduto);
            context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("produtos/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            context.Produtos.Remove(produto);
            context.SaveChanges();
            return Ok(produto);
        }
    }
}
