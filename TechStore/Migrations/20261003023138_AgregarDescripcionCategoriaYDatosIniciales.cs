using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechStore.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDescripcionCategoriaYDatosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Productos",
                newName: "Nombre");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Productos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Productos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categorias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Smartphones de última generación.", "Celulares" },
                    { 2, "GPUs para gaming y trabajo profesional.", "Tarjetas de video" },
                    { 3, "Consolas de videojuegos de sobremesa y portátiles.", "Consolas" },
                    { 4, "Auriculares, parlantes y accesorios de sonido.", "Audio" },
                    { 5, "Laptops para estudio, trabajo y gaming.", "Notebooks" },
                    { 6, "Tablets para productividad y entretenimiento.", "Tablets" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ID", "CategoriaId", "Descripcion", "Estado", "ImagenUrl", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Diseño revolucionario en aluminio de grado aeroespacial, impulsado por el nuevo chip A18 para un rendimiento ultrarrápido y máxima eficiencia.", "Disponible", "/images/iphone_16.jpg", "IPhone 16", 1250m, 10 },
                    { 2, 2, "Lleva tu experiencia visual al extremo. Diseñada bajo la avanzada arquitectura NVIDIA Blackwell y respaldada por 16 GB de memoria ultra rápida GDDR7.", "Disponible", "/images/asus_prime_rtx_5080.jpg", "Asus Prime RTX 5080", 1500m, 16 },
                    { 3, 3, "Consola portátil de videojuegos con pantalla OLED de colores vibrantes, negros puros y una batería de mayor duración.", "Disponible", "/images/steam_deck.jpg", "Steam Deck OLED", 980.65m, 4 },
                    { 4, 4, "Auriculares inalámbricos de gama alta con la cancelación de ruido activa líder de la industria y un perfil de sonido de alta definición.", "Disponible", "/images/sony_wh1000xm6.jpg", "Sony WH-1000XM6", 340m, 8 },
                    { 5, 5, "La laptop más potente de Apple, con el chip M3 Pro y una pantalla Retina de 16 pulgadas.", "Disponible", "/images/macbookpro.jpg", "MacBook Pro 16\"", 2499m, 6 },
                    { 6, 6, "La tablet más rápida de Apple, con el chip M1 y una pantalla Liquid Retina de 10.9 pulgadas.", "Disponible", "/images/airpadair.jpg", "iPad Air", 599m, 12 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Productos",
                newName: "Titulo");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categorias");

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "Productos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
