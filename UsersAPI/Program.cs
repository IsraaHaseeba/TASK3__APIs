using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;
using UsersAPI;
using UsersAPI.API.DemoSample.Exceptions;
using UsersAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.services();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();


app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
