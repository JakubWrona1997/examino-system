global using Examino.Infrastructure;
global using Examino.Domain.Entities;
using System.Text;
using Examino.Application;
using Examino.Application.Hubs;
using Examino.Domain.TokenClasses;
using Examino.Infrastructure.Middleware;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;

builder.Host.AddExaminoInfrastructureHostConfiguration();
//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Jwt token 
var authenticationSettings = new AuthenticationSettings();
Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddHangfire(configuration =>
    configuration.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfireServer();
builder.Services.AddSignalR();

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});

//password hasher
builder.Services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
builder.Services.AddScoped<IPasswordHasher<Patient>, PasswordHasher<Patient>>();
builder.Services.AddScoped<IPasswordHasher<Doctor>, PasswordHasher<Doctor>>();
// Add services to the container.
builder.Services.AddControllers();

//Infrastructure services registration
builder.Services.AddExaminoInfrastructureServices(Configuration);

//Application services registration
builder.Services.AddApplicationServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors(builder =>
{
    builder
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseMiddleware<AuthorizationHeaderMiddleware>();

app.MapHub<EventHub>("/hub");

app.UseAuthentication();

app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseAuthorization();

app.MapControllers();

app.Run();
