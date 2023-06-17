using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KROBEL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreatePersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    last_name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    phone_number = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    gender = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personid", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
