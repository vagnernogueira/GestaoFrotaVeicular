using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFrotaVeicular.EndPoints
{
    public static class VehicleExtension
    {
        public static void AddEndPointVehicle(this WebApplication app)
        {
            app.MapGet("/Vehicle", ([FromServices] DAL<Vehicle> dal) =>
            {
                return Results.Ok(dal.Read());
            });

            app.MapGet("/Vehicle/{id}", ([FromServices] DAL<Vehicle> dal, [FromRoute] int id) =>
            {
                var vehicle = dal.ReadBy(v => v.Id == id);
                if (vehicle == null)
                    return Results.NotFound();
                return Results.Ok(vehicle);
            });

            app.MapPost("/Vehicle", ([FromServices] DAL<Vehicle> dal, [FromBody] Vehicle vehicle) =>
            {
                dal.Create(vehicle);
                return Results.Created($"/Vehicle/{vehicle.Id}", vehicle);
            });

            app.MapDelete("/Vehicle/{id}", ([FromServices] DAL<Vehicle> dal, [FromRoute] int id) =>
            {
                var vehicle = dal.ReadBy(v => v.Id == id);
                if (vehicle == null)
                    return Results.NotFound();
                dal.Delete(vehicle);
                return Results.NoContent();
            });

            app.MapPut("/Vehicle", ([FromServices] DAL<Vehicle> dal, [FromBody] Vehicle vehicle) =>
            {
                var existingVehicle = dal.ReadBy(v => v.Id == vehicle.Id);
                if (existingVehicle == null)
                    return Results.NotFound();
                existingVehicle.MarkModel = vehicle.MarkModel;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.Plate = vehicle.Plate;
                dal.Update(existingVehicle);
                return Results.Ok(existingVehicle);
            });
        }
    }
}
