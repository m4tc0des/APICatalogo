using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext : DbContext // Classe que representa o contexto do banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Construtor que recebe as opções do DbContext
        {
        }
        public DbSet<Category>? Categorys { get; set; } // Propriedade que representa a tabela de categorias no banco de dados
        public DbSet<Products>? Products { get; set; } // Propriedade que representa a tabela de produtos no banco de dados
        public AppDbContext()
        {
        }

    }

}
