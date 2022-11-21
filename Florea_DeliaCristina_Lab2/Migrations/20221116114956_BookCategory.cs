using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Florea_DeliaCristina_Lab2.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorsId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "Book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorsId",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookID",
                table: "BookCategory",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryID",
                table: "BookCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Book",
                newName: "AuthorsId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorsId",
                table: "Book",
                column: "AuthorsId",
                principalTable: "Author",
                principalColumn: "Id");
        }
    }
}
