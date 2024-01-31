using EmployeeCRUD_BE.GenericRepository;
using EmployeeCRUD_BE.Interfaces;
using EmployeeCRUD_BE.Models;
using EmployeeCRUD_BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDCS")));

builder.Services.AddControllers();
builder.Services.AddScoped<EmployeeContext>(); // Register your EmployeeContext
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); // Register your EmployeeService

// If IGenericRepository<Employee> is implemented, register it too.
builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
