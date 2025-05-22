using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFrotaVeicular.EndPoints
{
    public static class VehicleTypeExtension
    {
        public static void AddEndPointVehicleType(this WebApplication app)
        {
            app.MapGet("/VehicleType", ([FromServices] DAL<VehicleType> dal) =>
            {
                return Results.Ok(dal.Read());
            });

            app.MapGet("/VehicleType/{id}", ([FromServices] DAL<VehicleType> dal, [FromRoute] int id) =>
            {
                var vehicleType = dal.ReadBy(v => v.Id == id);
                if (vehicleType == null)
                    return Results.NotFound();
                return Results.Ok(vehicleType);
            });

            app.MapPost("/VehicleType", ([FromServices] DAL<VehicleType> dal, [FromBody] VehicleType vehicleType) =>
            {
                dal.Create(vehicleType);
                return Results.Created($"/VehicleType/{vehicleType.Id}", vehicleType);
            });

            app.MapDelete("/VehicleType/{id}", ([FromServices] DAL<VehicleType> dal, [FromRoute] int id) =>
            {
                var vehicleType = dal.ReadBy(v => v.Id == id);
                if (vehicleType == null)
                    return Results.NotFound();
                dal.Delete(vehicleType);
                return Results.NoContent();
            });

            app.MapPut("/VehicleType", ([FromServices] DAL<VehicleType> dal, [FromBody] VehicleType vehicleType) =>
            {
                var existingVehicleType = dal.ReadBy(v => v.Id == vehicleType.Id);
                if (existingVehicleType == null)
                    return Results.NotFound();
                existingVehicleType.Name = vehicleType.Name;
                existingVehicleType.Description = vehicleType.Description;
                dal.Update(existingVehicleType);
                return Results.Ok(existingVehicleType);
            });
        }
    }
}
