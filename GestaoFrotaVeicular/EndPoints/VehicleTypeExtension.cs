using GestaoFrotaVeicular.Requests;
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
                var vehicleTypeList = dal.Read();
                if (vehicleTypeList is null || !vehicleTypeList.Any())
                    return Results.NotFound();
                var responseList = EntityListToResponseList(vehicleTypeList);
                return Results.Ok(responseList);
            });

            app.MapGet("/VehicleType/{id}", ([FromServices] DAL<VehicleType> dal, [FromRoute] int id) =>
            {
                var vehicleType = dal.ReadBy(v => v.Id == id);
                if (vehicleType == null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(vehicleType));
            });

            app.MapPost("/VehicleType", ([FromServices] DAL<VehicleType> dal, [FromBody] VehicleTypeRequest vehicleTypeRequest) =>
            {
                VehicleType vehicleType = RequestToEntity(vehicleTypeRequest);
                dal.Create(vehicleType);
                return Results.Created($"/VehicleType/{vehicleType.Id}", vehicleType.Id);
            });

            app.MapDelete("/VehicleType/{id}", ([FromServices] DAL<VehicleType> dal, [FromRoute] int id) =>
            {
                var vehicleType = dal.ReadBy(v => v.Id == id);
                if (vehicleType == null)
                    return Results.NotFound();
                dal.Delete(vehicleType);
                return Results.NoContent();
            });

            app.MapPut("/VehicleType", ([FromServices] DAL<VehicleType> dal, [FromBody] VehicleTypeEditRequest vehicleTypeEditRequest) =>
            {
                var existingVehicleType = dal.ReadBy(v => v.Id == vehicleTypeEditRequest.id);
                if (existingVehicleType == null)
                    return Results.NotFound();
                existingVehicleType.Name = vehicleTypeEditRequest.name;
                existingVehicleType.Description = vehicleTypeEditRequest.description;
                dal.Update(existingVehicleType);
                return Results.Ok(EntityToResponse(existingVehicleType));
            });
        }
        private static List<VehicleType> RequestListToEntityList(ICollection<VehicleTypeRequest> requestList, DAL<VehicleType> dal)
        {
            var entityList = new List<VehicleType>();
            foreach (var item in requestList)
            {
                var entity = RequestToEntity(item);
                var entityFound = dal.ReadBy(e => e.Name.ToUpper().Equals(entity.Name.ToUpper()));
                if (entityFound is not null) entityList.Add(entityFound);
                else entityList.Add(entity);
            }
            return entityList;
        }

        private static VehicleType RequestToEntity(VehicleTypeRequest request)
        {
            return new VehicleType() { Name = request.name, Description = request.description };
        }

        private static ICollection<VehicleTypeResponse> EntityListToResponseList(IEnumerable<VehicleType> entityList)
        {
            return entityList.Select(a => EntityToResponse(a)).ToList();
        }
        private static VehicleTypeResponse EntityToResponse(VehicleType entity)
        {
            return new VehicleTypeResponse(entity.Id, entity.Name, entity.Description);
        }
    }
}
