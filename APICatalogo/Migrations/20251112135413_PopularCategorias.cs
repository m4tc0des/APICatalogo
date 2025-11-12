using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations // Namespace para migrações do Entity Framework
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration // Migração para popular a tabela de categorias com dados iniciais
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb) // Popula a tabela de categorias com dados iniciais
        {
            mb.Sql("INSERT INTO Category (Name, ImageUrl) VALUES('Bebidas', 'bebidas.png')");

            mb.Sql("INSERT INTO Category (Name, ImageUrl) VALUES('Lanches', 'lanches.png')");

            mb.Sql("INSERT INTO Category (Name, ImageUrl) VALUES('Sobremesas', 'sobremesas.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb) // Remove os dados inseridos na tabela de categorias
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
