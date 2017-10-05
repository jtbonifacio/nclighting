using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NCLBackend.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAmt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IMAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITEM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ITEM_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ON_HAND_QTY = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monthly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAmt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quarterly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAmt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarterly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MONTHLY_QUOTA = table.Column<int>(type: "int", nullable: false),
                    REPNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YEARLY_QUOTA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOGIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSITION = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weekly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAmt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yearly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SALES_REP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesAmt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yearly", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Monthly");

            migrationBuilder.DropTable(
                name: "Quarterly");

            migrationBuilder.DropTable(
                name: "Quota");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Weekly");

            migrationBuilder.DropTable(
                name: "Yearly");
        }
    }
}
