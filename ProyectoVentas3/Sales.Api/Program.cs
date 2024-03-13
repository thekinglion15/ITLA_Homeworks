using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;
using Sales.IOC.BusinessDependencies;
using Sales.IOC.CategoryDependencies;
using Sales.IOC.ConfigurationDependencies;
using Sales.IOC.CorrelativeNumberDependencies;
using Sales.IOC.MenuDependencies;
using Sales.IOC.ProductDependencies;
using Sales.IOC.RoleDependencies;
using Sales.IOC.RoleMenuDependencies;
using Sales.IOC.SaleDependencies;
using Sales.IOC.SaleDetailDependencies;
using Sales.IOC.TypeDocSaleDependencies;
using Sales.IOC.UserDependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessContext")));

//Dependencias
builder.Services.AddBusinessDependency();
builder.Services.AddCategoryDependency();
builder.Services.AddConfigurationDependency();
builder.Services.AddCorrelativeNumberDependency();
builder.Services.AddMenuDependency();
builder.Services.AddProductDependency();
builder.Services.AddRoleDependency();
builder.Services.AddRoleMenuDependency();
builder.Services.AddSaleDependency();
builder.Services.AddSaleDetailDependency();
builder.Services.AddTypeDocSaleDependency();
builder.Services.AddUserDependency();

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
