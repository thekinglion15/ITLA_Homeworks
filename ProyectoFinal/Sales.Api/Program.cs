using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.IOC.BusinessDependencies;
using Sales.IOC.SaleDependencies;
using Sales.IOC.SaleDetailDependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessContext")));

//Dependencias
builder.Services.AddBusinessDependency();
builder.Services.AddSaleDependency();
builder.Services.AddSaleDetailDependency();

// Add services to the container.
//builder.Services.AddScoped<IBusinessDb, BusinessDb>();

//App Services
//builder.Services.AddTransient<IBusinessService, BusinessService>();

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
