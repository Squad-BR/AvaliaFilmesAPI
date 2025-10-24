using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Business.Service;
using AvaliaFilmesAPI.Data.Context;
using AvaliaFilmesAPI.Data.Repositories;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

//Escopo do rpositório
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//Escopo do serviço
builder.Services.AddScoped<IFilmeService, FilmeService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
