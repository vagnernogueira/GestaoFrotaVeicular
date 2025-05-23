using GestaoFrotaVeicular.EndPoints;
using GestaoFrotaVeicular.Shared.Data.DB;
using GestaoFrotaVeicular.Shared.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.WriteIndented = true;
});
builder.Services.AddDbContext<GestaoFrotaVeicularContext>();
builder.Services.AddTransient<DAL<Vehicle>>();
builder.Services.AddTransient<DAL<VehicleType>>();
builder.Services.AddTransient<DAL<Department>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Gestão de Frota Veicular", Version = "v1" });
});
var app = builder.Build();

app.AddEndPointVehicle();
app.AddEndPointVehicleType();
app.AddEndPointDepartment();

/**
 <see cref="http://localhost:5101/Swagger/index.html"/>
 */
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
