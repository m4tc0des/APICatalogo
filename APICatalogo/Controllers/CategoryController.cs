using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Category>> GetCategoriasProduto()
        {
            return _context.Categorys.Include(x => x.Products).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categorys.ToList();
        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            var categorys = _context.Products.FirstOrDefault(x => x.CategoryId == id);
            if (categorys is null)
            {
                return NotFound("Categoria nao encontrada. Verifique!");
            }
            return Ok(categorys);
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            _context.Categorys.Add(category);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoria", new { id = category.CategoryId}, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Atualizacao nao concluida. Verifique!");
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(category);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context.Products.FirstOrDefault(x => x.CategoryId == id);
            if (category is null)
            {
                return NotFound("Categoria nao encontrada. Verifique!");
            }
            _context.Products.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}

