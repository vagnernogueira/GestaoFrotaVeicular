namespace GestaoFrotaVeicular.Requests
{
    public record VehicleEditRequest(int id, string markModel, int year, string plate);
}
