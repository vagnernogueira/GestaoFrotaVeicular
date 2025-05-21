using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFrotaVeicular.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[,]
                {
                    { 1, "Carro", "Veículo de passeio" },
                    { 2, "Caminhão", "Veículo de carga" },
                    { 3, "Moto", "Veículo de duas rodas" }
                });
            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "MarkModel", "Plate", "VehicleTypeId", "Year" },
                values: new object[,]
                {
                    { 1, "Fusca", "ABC-1234", 1, 1970 },
                    { 2, "Civic", "XYZ-5678", 1, 2020 },
                    { 3, "F-4000", "DEF-9012", 2, 2015 },
                    { 4, "CB500", "GHI-3456", 3, 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Vehicle");
            migrationBuilder.Sql("DELETE FROM VehicleType");
        }
    }
}
