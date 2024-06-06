using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyWeb_Razor.Migrations
{
    /// <inheritdoc />
    public partial class CreatingRelativesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelativesTable",
                columns: table => new
                {
                    RelativeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativesTable", x => x.RelativeId);
                });

            migrationBuilder.InsertData(
                table: "RelativesTable",
                columns: new[] { "RelativeId", "Relationship", "RelativeName" },
                values: new object[,]
                {
                    { 1, "Father", "Sathiyamoorthy" },
                    { 2, "Mother", "Sivakami" },
                    { 3, "Brother", "Rathinam" },
                    { 4, "Sons", "Ashwin&Appu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelativesTable");
        }
    }
}
