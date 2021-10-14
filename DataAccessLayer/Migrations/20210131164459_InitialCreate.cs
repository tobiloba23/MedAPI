using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blood_Work",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    exam_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    results_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", nullable: false),
                    hemoglobin = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    hematocrit = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    white_blood_cell_count_mcpmcl = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    red_blood_cell_count_mcpmcl = table.Column<decimal>(type: "decimal(6,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood_Work", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blood_Work");
        }
    }
}
