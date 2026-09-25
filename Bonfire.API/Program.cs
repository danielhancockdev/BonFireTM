
using Microsoft.EntityFrameworkCore;

using Bonfire.Application.Interfaces;
using Bonfire.Application.Services;

using Bonfire.Infrastructure.Data;
using Bonfire.Infrastructure.Repositories;
using Bonfire.Infrastructure.Services;
using Bonfire.Infrastructure.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Register Entity Framework Core
builder.Services.AddDbContext<BonfireDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Register Application Services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();

// Register Infrastructure Services
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Register Configuration Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));


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
