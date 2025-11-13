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
            try
            {
                return _context.Categorys.AsNoTracking().Include(x => x.Products).ToList();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação. Verifique");
            }        
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                return _context.Categorys.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação. Verifique");
            }

        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var categorys = _context.Products.FirstOrDefault(x => x.CategoryId == id);
                if (categorys is null)
                {
                    return NotFound("Categoria nao encontrada. Verifique!");
                }
                return Ok(categorys);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação. Verifique");
            }
        }
        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            try
            {
                if(category is null)
            {
                    return BadRequest("Dados invalidos. Verifique.");
                }
                _context.Categorys.Add(category);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterCategoria", new { id = category.CategoryId }, category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu um erro ao tratar sua solicitação. Verifique");
            }
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
                return NotFound($"Categoria com a id {id} nao encontrada. Verifique!");
            }
            _context.Products.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}

