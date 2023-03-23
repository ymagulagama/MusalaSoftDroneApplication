using Microsoft.EntityFrameworkCore;
using MusalaSoftDrones.Api.Data;
using MusalaSoftDrones.Api.DomainEntities;
using MusalaSoftDrones.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusalaSoftAppApiContext>(c => c.UseInMemoryDatabase("MusalaSoftDb"));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions
.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMusalaSoftRepository, MusalaSoftRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
