using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                   "VALUES('Coca-Cola', 'Refrigerante de cola 350ml', 5.00, 'coca_cola.png', 52, NOW(), 1)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                   "VALUES('Sanduiche Frango', 'Sanduiche de Frango 200g', 9.00, 'sanduiche_frango.png', 30, NOW(), 2)");

            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, RegisterDate, CategoryId) " +
                   "VALUES('Pudim', 'Pudim gelado 100g', 7.00, 'pudim.png', 12, NOW(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
