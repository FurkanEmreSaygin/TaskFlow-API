using TaskFlow.DataAccess;
using Microsoft.EntityFrameworkCore;
using TaskFlow.DataAccess.Db;
using TaskFlow.DataAccess.Interfaces;
using TaskFlow.DataAccess.Repositories;
using TaskFlow.Business.Interfaces;
using TaskFlow.Business.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGorevRepository, GorevRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGorevService, GorevService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskFlowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
