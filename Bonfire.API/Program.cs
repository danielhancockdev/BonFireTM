using Bonfire.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Bonfire.Application.Interfaces;
using Bonfire.Infrastructure.Repositories;
using Bonfire.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Entity Framework Core
builder.Services.AddDbContext<BonfireDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// Register Application Services
builder.Services.AddScoped<IProjectService, ProjectService>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
