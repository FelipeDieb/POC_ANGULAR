using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PocAPI.Model;

namespace PocAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    StartMonth = table.Column<int>(nullable: false),
                    DepartamentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Departament_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartamentId",
                table: "Employee",
                column: "DepartamentId");

            migrationBuilder.Sql("INSERT INTO Departament (Name, CreatedAt, UpdatedAt) VALUES ('Sales', NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Departament (Name, CreatedAt, UpdatedAt) VALUES ('Marketing', NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Departament (Name, CreatedAt, UpdatedAt) VALUES ('Finances', NOW(), NOW())");

            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Sam', 1, 100, 1, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Vinod', 1, 200, 1, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Paul', 2, 500, 3, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Kumar', 3, 200, 2, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Veena', 2, 300, 6, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Keith', 3, 800, 3, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Alex', 2, 1000, 1, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Renuka', 1, 200, 3, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Kelly', 1, 100, 3, NOW(), NOW())");
            migrationBuilder.Sql("INSERT INTO Employee (Name, DepartamentId, Salary, StartMonth, CreatedAt, UpdatedAt) VALUES ('Cara', 3, 200, 6, NOW(), NOW())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departament");
        }

        private void InsertDefaultData()
        {
        }
    }
}
