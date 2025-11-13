using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()
        {
            try
            {
                var products = _context.Products.AsNoTracking().ToList();
                if (products is null)
                {
                    return NotFound();
                }
                return products;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação.Verifique");
            }
            
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Products> Get(int id)
        {
            try
            {
                var product = _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == id);
                if (product is null)
                {
                    return NotFound("Produto nao encontrado. Verifique!");
                }
                return product;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação.Verifique");
            }

        }
        [HttpPost]
        public ActionResult<Products> Post(Products product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest("Cadastro nao concluido.Verifique!");
                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterProduto", new { id = product.ProductId }, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação.Verifique");
            }

        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Products product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return BadRequest("Atualizacao nao concluida.Verifique!");
                }
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação.Verifique");
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product is null)
                {
                    return NotFound($"Produto com a id= {id} nao existe.Verifique!");
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação.Verifique");
            }
        }
    }
}
