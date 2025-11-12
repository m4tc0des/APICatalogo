using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase // Controlador para gerenciar produtos
    {
        private readonly AppDbContext _context; // Usado para acessar os dados de produtos no banco

        // Injeta o contexto do banco para acessar os dados
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()  // Action para obter todos os produtos
        {
            var products = _context.Products.ToList();
            if (products is null) // Verifica se a lista de produtos está vazia
            {
                return NotFound();
            }
            return products;
        }
        [HttpGet("{id:int}",Name = "ObterProduto")]
        public ActionResult<Products> Get(int id) // Action para obter um produto específico pelo ID usando expressão lambda
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

    }
}
