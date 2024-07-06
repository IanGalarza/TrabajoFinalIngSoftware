using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVentasCafe.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__D59466421629B4E8", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "MEDIODEPAGO",
                columns: table => new
                {
                    IdMedioDePago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    NumeroDeTarjeta = table.Column<int>(type: "int", nullable: false),
                    FechaDeCaducidad = table.Column<DateOnly>(type: "date", nullable: true),
                    CodigoDeSeguridad = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionDeFacturacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MEDIODEP__6B4A4BA22B848B08", x => x.IdMedioDePago);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StockActual = table.Column<int>(type: "int", nullable: true),
                    NumeroDeLote = table.Column<int>(type: "int", nullable: true),
                    fechaVencimiento = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTO__0988921094777190", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "FACTURA",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFactura = table.Column<DateOnly>(type: "date", nullable: true),
                    CantidadProductos = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    EstadoPago = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FACTURA__50E7BAF1153F5D44", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_IDCLIENTE",
                        column: x => x.IdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COBRANZA",
                columns: table => new
                {
                    IdCobranza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    fechaDeCobro = table.Column<DateOnly>(type: "date", nullable: true),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false),
                    MedioDePago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__COBRANZA__7B29BE86A8CEAEB7", x => x.IdCobranza);
                    table.ForeignKey(
                        name: "FK_MEDIODEPAGO",
                        column: x => x.MedioDePago,
                        principalTable: "MEDIODEPAGO",
                        principalColumn: "IdMedioDePago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NUMEROFACTURA",
                        column: x => x.NumeroFactura,
                        principalTable: "FACTURA",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FACTURAPRODUCTOS",
                columns: table => new
                {
                    IdFacturaProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadDelProducto = table.Column<int>(type: "int", nullable: true),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FACTURAP__36F787A4DE48DE03", x => x.IdFacturaProductos);
                    table.ForeignKey(
                        name: "FK_IDFACTURA",
                        column: x => x.IdFactura,
                        principalTable: "FACTURA",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDPRODUCTO",
                        column: x => x.IdProducto,
                        principalTable: "PRODUCTO",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COBRANZA_MedioDePago",
                table: "COBRANZA",
                column: "MedioDePago");

            migrationBuilder.CreateIndex(
                name: "IX_COBRANZA_NumeroFactura",
                table: "COBRANZA",
                column: "NumeroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURA_IdCliente",
                table: "FACTURA",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAPRODUCTOS_IdFactura",
                table: "FACTURAPRODUCTOS",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAPRODUCTOS_IdProducto",
                table: "FACTURAPRODUCTOS",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COBRANZA");

            migrationBuilder.DropTable(
                name: "FACTURAPRODUCTOS");

            migrationBuilder.DropTable(
                name: "MEDIODEPAGO");

            migrationBuilder.DropTable(
                name: "FACTURA");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
