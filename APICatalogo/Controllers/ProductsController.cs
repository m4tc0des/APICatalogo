using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
            var products = _context.Products.ToList();
            if (products is null) 
            {
                return NotFound();
            }
            return products;
        }
        [HttpGet("{id:int}",Name = "ObterProduto")]
        public ActionResult<Products> Get(int id) 
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product is null)
            {
                return NotFound("Produto nao encontrado. Verifique!");
            }
            return product;
        }
        [HttpPost]
        public ActionResult<Products> Post(Products product) 
        { if (product is null)
            {
                return BadRequest("Cadastro nao concluido. Verifique!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = product.ProductId }, product); 
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Products product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Atualizacao nao concluida. Verifique!");
            }
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
