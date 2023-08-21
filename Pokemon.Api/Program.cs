using Microsoft.EntityFrameworkCore;
using Pokemon.Application.Interfaces;
using Pokemon.Application.Mapping;
using Pokemon.Application.Services;
using Pokemon.Data;
using Pokemon.Domain.Interfaces;
using Pokemon.Infrastructure.Configuration;
using Pokemon.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string EXTERNAL_BASE_URL = "https://pokeapi.co/api/v2";

//Banco rodando no docker
//var server = builder.Configuration["DbServer"] ?? "localhost";
//var port = builder.Configuration["DbPort"] ?? "1450";
//var user = builder.Configuration["DbUser"] ?? "SA";
//var password = builder.Configuration["Password"] ?? "NumSey#2023";
//var database = builder.Configuration["Database"] ?? "PokemonDb";

//var connectionString = $"Server={server}, {port};Initial Catalog={database}; User ID={user};Password={password}";

var connectionString = builder.Configuration.GetConnectionString("PokemonDatabase");

builder.Services.AddDbContext<TrainerPokemonDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();


builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IPokemonCaughtRepository, PokemonCaughtRepository>();
builder.Services.AddScoped<IPokemonCaughtService, PokemonCaughtService>();

builder.Services.AddAutoMapper(typeof(MappingPokemon));

builder.Services.AddSingleton(new ExternalApiConfiguration(EXTERNAL_BASE_URL));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
