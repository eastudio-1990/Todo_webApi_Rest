using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using WebApplication1.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ToDoRepository,ToDoRepository>();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseContext>(d=>d.UseSqlServer("Server=.;Initial Catalog=MYAPIDB;Integrated Security=True;Encrypt=False"));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
