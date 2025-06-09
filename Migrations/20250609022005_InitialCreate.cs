using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeMottu.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NETFLD_Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroSerie = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    LimiteAlerta = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IntervaloHoras = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NETFLD_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NETFLD_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NETFLD_Usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NETFLD_Sensor");

            migrationBuilder.DropTable(
                name: "NETFLD_Usuario");
        }
    }
}
