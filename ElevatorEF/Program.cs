using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AllDbContext>(option=>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbCs")));

        builder.Services.AddCors(option =>

        option.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();

        }
        ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
