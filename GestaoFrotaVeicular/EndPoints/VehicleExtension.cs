using GestaoFrotaVeicular.Requests;
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
                var vehicleList = dal.Read();
                if (vehicleList is null || !vehicleList.Any())
                    return Results.NotFound();
                var responseList = EntityListToResponseList(vehicleList);
                return Results.Ok(responseList);
            });

            app.MapGet("/Vehicle/{id}", ([FromServices] DAL<Vehicle> dal, [FromRoute] int id) =>
            {
                var vehicle = dal.ReadBy(v => v.Id == id);
                if (vehicle == null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(vehicle));
            });

            app.MapPost("/Vehicle", ([FromServices] DAL<Vehicle> ndal, [FromServices] DAL<Department> mdal, [FromBody] VehicleRequest vehicleRequest) =>
            {
                var vehicle = RequestToEntity(vehicleRequest, mdal);
                ndal.Create(vehicle);
                return Results.Created($"/Vehicle/{vehicle.Id}", vehicle.Id);
            });

            app.MapDelete("/Vehicle/{id}", ([FromServices] DAL<Vehicle> dal, [FromRoute] int id) =>
            {
                var vehicle = dal.ReadBy(v => v.Id == id);
                if (vehicle == null)
                    return Results.NotFound();
                dal.Delete(vehicle);
                return Results.NoContent();
            });

            app.MapPut("/Vehicle", ([FromServices] DAL<Vehicle> dal, [FromBody] VehicleEditRequest vehicleEditRequest) =>
            {
                var existingVehicle = dal.ReadBy(v => v.Id == vehicleEditRequest.id);
                if (existingVehicle == null)
                    return Results.NotFound();
                existingVehicle.MarkModel = vehicleEditRequest.markModel;
                existingVehicle.Year = vehicleEditRequest.year;
                existingVehicle.Plate = vehicleEditRequest.plate;
                dal.Update(existingVehicle);
                return Results.Ok(EntityToResponse(existingVehicle));
            });
        }

        private static List<Vehicle> RequestListToEntityList(ICollection<VehicleRequest> requestList, DAL<Vehicle> ndal, DAL<Department> mdal)
        {
            var entityList = new List<Vehicle>();
            foreach (var item in requestList)
            {
                var entity = RequestToEntity(item, mdal);
                var entityFound = ndal.ReadBy(e => e.Plate.ToUpper().Equals(entity.Plate.ToUpper()));
                if (entityFound is not null) entityList.Add(entityFound);
                else entityList.Add(entity);
            }
            return entityList;
        }

        private static Vehicle RequestToEntity(VehicleRequest request, DAL<Department> mdal)
        {
            return new Vehicle() {
                MarkModel = request.markModel,
                Year = request.year,
                Plate = request.plate,
                Departments = DepartmentExtension.RequestListToEntityList(request.departments, mdal)
            };
        }

        private static ICollection<VehicleResponse> EntityListToResponseList(IEnumerable<Vehicle> entityList)
        {
            return entityList.Select(a => EntityToResponse(a)).ToList();
        }
        private static VehicleResponse EntityToResponse(Vehicle entity)
        {
            return new VehicleResponse(entity.Id, entity.MarkModel, entity.Year, entity.Plate);
        }
    }
}
