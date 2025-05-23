namespace GestaoFrotaVeicular.Requests
{
    public record VehicleRequest(string markModel, int year, string plate, ICollection<DepartmentRequest>departments = null);
}
