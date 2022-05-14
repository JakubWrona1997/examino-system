global using Examino.Infrastructure;
global using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Examino.Infrastructure.Middleware;
using Examino.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddExaminoInfrastructureHostConfiguration();

ConfigurationManager Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();

//Infrastructure services registration
builder.Services.AddExaminoInfrastructureServices(Configuration);

//Application services registration
builder.Services.AddApplicationServices();

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
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
