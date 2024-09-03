using EmployeeTaskManager.DB;
using EmployeeTaskManager.Services;
using EmployeeTaskManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeTaskDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));


builder.Services.AddTransient<IEmployeesService, EmployeesService>();
builder.Services.AddTransient<ITaskService, TaskServices>();
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
