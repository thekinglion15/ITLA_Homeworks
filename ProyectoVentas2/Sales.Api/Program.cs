using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.DAO;
using Sales.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessContext")));

// Add services to the container.
builder.Services.AddTransient<IBusinessDb, BusinessDb>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
