using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Category")]
    public class Category // Classe que representa uma categoria de produtos
    {  
        [Key]
        public int CategoryId { get; set; } // Primary key
        [Required] // Indica que o campo é obrigatório
        [StringLength(80)] // Define o tamanho máximo da string
        public string? Name { get; set; } // Nome da categoria
        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; } // URL da imagem da categoria
        public ICollection<Product>? Products { get; set; } // Navigation property for related products
        public Category() // Construtor padrão que instancia a coleção de produtos
        {
            Products = new Collection<Product>();
        }
    }
}
