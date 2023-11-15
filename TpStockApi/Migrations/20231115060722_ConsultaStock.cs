using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpStockApi.Migrations
{
    public partial class ConsultaStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreProducto = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncargadoStockMovimiento",
                columns: table => new
                {
                    EncargadoStockId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovimientosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadoStockMovimiento", x => new { x.EncargadoStockId, x.MovimientosId });
                    table.ForeignKey(
                        name: "FK_EncargadoStockMovimiento_Movimiento_MovimientosId",
                        column: x => x.MovimientosId,
                        principalTable: "Movimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncargadoStockMovimiento_Users_EncargadoStockId",
                        column: x => x.EncargadoStockId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerenteMovimiento",
                columns: table => new
                {
                    GerenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovimientoIncrementoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerenteMovimiento", x => new { x.GerenteId, x.MovimientoIncrementoId });
                    table.ForeignKey(
                        name: "FK_GerenteMovimiento_Movimiento_MovimientoIncrementoId",
                        column: x => x.MovimientoIncrementoId,
                        principalTable: "Movimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerenteMovimiento_Users_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoVendedor",
                columns: table => new
                {
                    MovimientoDecrementoId = table.Column<int>(type: "INTEGER", nullable: false),
                    VendedoresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoVendedor", x => new { x.MovimientoDecrementoId, x.VendedoresId });
                    table.ForeignKey(
                        name: "FK_MovimientoVendedor_Movimiento_MovimientoDecrementoId",
                        column: x => x.MovimientoDecrementoId,
                        principalTable: "Movimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoVendedor_Users_VendedoresId",
                        column: x => x.VendedoresId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Descripcion", "NombreProducto" },
                values: new object[] { 1, 0, "Leche larga vida", "Leche" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Descripcion", "NombreProducto" },
                values: new object[] { 2, 0, "Arroz yamani", "Arroz" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Descripcion", "NombreProducto" },
                values: new object[] { 3, 0, "harina luedante", "Harina" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "UserName", "UserType" },
                values: new object[] { 2, "EmilioCerro@gmail.com", "Emilio Cerro", "321321", "E_Cerro", "EncargadoStock" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "UserName", "UserType" },
                values: new object[] { 1, "MicaelaCassino@gmail.com", "Micaela Caissno", "123123", "M_Cassino", "Gerente" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "UserName", "UserType" },
                values: new object[] { 3, "ValentinPAirone@gmail.com", "Valentin Pairone", "123456", "V_Pairone", "Vendedor" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "UserName", "UserType" },
                values: new object[] { 4, "MateoPAirone@gmail.com", "Mateo Pairone", "654321", "M_Pairone", "Vendedor" });

            migrationBuilder.CreateIndex(
                name: "IX_EncargadoStockMovimiento_MovimientosId",
                table: "EncargadoStockMovimiento",
                column: "MovimientosId");

            migrationBuilder.CreateIndex(
                name: "IX_GerenteMovimiento_MovimientoIncrementoId",
                table: "GerenteMovimiento",
                column: "MovimientoIncrementoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoVendedor_VendedoresId",
                table: "MovimientoVendedor",
                column: "VendedoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncargadoStockMovimiento");

            migrationBuilder.DropTable(
                name: "GerenteMovimiento");

            migrationBuilder.DropTable(
                name: "MovimientoVendedor");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
