using GestaoFrotaVeicular.Requests;
using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFrotaVeicular.EndPoints
{
    public static class DepartmentExtension
    {
        public static void AddEndPointDepartment(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("/Department/")
                .RequireAuthorization()
                .WithTags("Department");

            groupBuilder.MapGet("", ([FromServices] DAL<Department> dal) =>
            {
                var departmentList = dal.Read();
                if (departmentList is null || !departmentList.Any())
                    return Results.NotFound();
                var responseList = EntityListToResponseList(departmentList);
                return Results.Ok(responseList);
            });
            groupBuilder.MapGet("{id}", ([FromServices] DAL<Department> dal, [FromRoute] int id) =>
            {
                var department = dal.ReadBy(d => d.Id == id);
                if (department == null)
                    return Results.NotFound();
                return Results.Ok(EntityToResponse(department));
            });
            groupBuilder.MapPost("", ([FromServices] DAL<Department> dal, [FromBody] DepartmentRequest departmentRequest) =>
            {
                var department = RequestToEntity(departmentRequest);
                dal.Create(department);
                return Results.Created($"/Department/{department.Id}", department.Id);
            });
            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Department> dal, [FromRoute] int id) =>
            {
                var department = dal.ReadBy(d => d.Id == id);
                if (department == null)
                    return Results.NotFound();
                dal.Delete(department);
                return Results.NoContent();
            });
            groupBuilder.MapPut("", ([FromServices] DAL<Department> dal, [FromBody] DepartmentEditRequest departmentEditRequest) =>
            {
                var existingDepartment = dal.ReadBy(d => d.Id == departmentEditRequest.id);
                if (existingDepartment == null)
                    return Results.NotFound();
                existingDepartment.Name = departmentEditRequest.name;
                existingDepartment.Description = departmentEditRequest.description;
                dal.Update(existingDepartment);
                return Results.Ok(EntityToResponse(existingDepartment));
            });
        }

        public static List<Department> RequestListToEntityList(ICollection<DepartmentRequest> requestList, DAL<Department> dal)
        {
            var entityList = new List<Department>();
            foreach (var item in requestList)
            {
                var entity = RequestToEntity(item);
                var entityFound = dal.ReadBy(e => e.Name.ToUpper().Equals(entity.Name.ToUpper()));
                if (entityFound is not null) entityList.Add(entityFound);
                else entityList.Add(entity);
            }
            return entityList;
        }

        private static Department RequestToEntity(DepartmentRequest request)
        {
            return new Department() { Name = request.name, Description = request.description };
        }

        private static ICollection<DepartmentResponse> EntityListToResponseList(IEnumerable<Department> entityList)
        {
            return entityList.Select(a => EntityToResponse(a)).ToList();
        }

        private static DepartmentResponse EntityToResponse(Department entity)
        {
            return new DepartmentResponse(entity.Id, entity.Name, entity.Description);
        }
    }
}
