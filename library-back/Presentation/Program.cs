using Library.Business.Services;
using Library.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;
using Library.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection of repositories
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

//dependency injection of services
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

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
