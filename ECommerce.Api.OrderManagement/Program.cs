using ECommerce.Api.OrderManagement.Aplication;
using ECommerce.Api.OrderManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
  {
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
  }
);

builder.Services.AddCors();
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(New.Manejador).Assembly);

var stringConection = builder.Configuration["ConnectionStrings:ConetionDatabase"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<CarContext>(options =>
{
  options.UseMySql(stringConection, serverVersion);
});

var app = builder.Build();

app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .SetIsOriginAllowed(origin => true)
   .AllowCredentials());

  using (var scope = app.Services.CreateScope())
  {
    CarContext context = scope.ServiceProvider.GetRequiredService<CarContext>();
    context.Database.Migrate();
  }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();