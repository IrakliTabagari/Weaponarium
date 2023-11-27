using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.Application.Services;
using Server.Domain.Constants;
using Server.Domain.Entities;
using Server.Domain.Interfaces.Services;
using Server.Domain.Interfaces.UnitOfWork;
using Server.Infrastructure.Config;
using Server.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle// Add services to the container.

// Options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

// For Entity Framework
builder.Services.AddDbContext<WeaponariumDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// For Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<WeaponariumDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // Adding Jwt Bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"] ?? string.Empty))
        };
    });
        
builder.Services.AddAuthorization(options =>
{
    foreach (var permission in PermissionsManager.GetAllPermissions())
    {
        options.AddPolicy(permission.Value.Name, policy => policy.RequireClaim(CustomClaims.Permissions, permission.Value.Name));
    }
});


// Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();