using Madrasa.Api;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Madrasa.Api.Repository;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MadrasaDb>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IElevesRepository, ElevesRepository>();
builder.Services.AddScoped<IMaisonRepository, MaisonRepository>();
builder.Services.AddScoped<IProfesseursRepository, ProfesseursRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAnyOrigin");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

