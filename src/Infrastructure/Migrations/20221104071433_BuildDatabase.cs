using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class BuildDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 12, "Student 1" },
                    { 2, 13, "Student 2" },
                    { 3, 14, "Student 3" },
                    { 4, 21, "Student 4" },
                    { 5, 12, "Student 5" },
                    { 6, 23, "Student 6" },
                    { 7, 25, "Student 7" },
                    { 8, 29, "Student 8" },
                    { 9, 17, "Student 9" },
                    { 10, 18, "Student 10" },
                    { 11, 23, "Student 11" },
                    { 12, 24, "Student 12" },
                    { 13, 19, "Student 13" },
                    { 14, 20, "Student 14" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
