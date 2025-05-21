using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.WriteIndented = true;
});
var app = builder.Build();
app.MapGet("/", () =>
    {
        var dal = new DAL<Vehicle>();
        return dal.Read();
    });
app.Run();
