using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Resume.Data;
using Resume.Models;
using Resume.Repository;
using Resume.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add controllers so swagger can read the controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For newtonsoft services
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ITokenService, TokenServices>();

// Connect to Database
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnections")));

// For Identity
builder.Services.AddIdentity<AppUsers, IdentityRole>(option => {
    // Add password requirements
    option.Password.RequireDigit = true; // Password must contain at least one digit
    option.Password.RequireLowercase = true; // Password must contain at least one lowercase letter
    option.Password.RequireUppercase = true; // Password must contain at least one uppercase letter
})
// Use Entity Framework to store identity data, like users and roles, in the ApplicationDbContext database
.AddEntityFrameworkStores<ApplicationDbContext>();

// Scheme, add JWT
builder.Services.AddAuthentication(options => {
    // Set JWT Bearer as the default scheme for authenticating requests
    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme = 
    options.DefaultForbidScheme = 
    options.DefaultScheme = 
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Add JWT Bearer authentication
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Validate the issuer of the token (JWT)
        ValidIssuer = builder.Configuration["JWT:Issuer"], // Set the valid issuer from the configuration

        ValidateAudience = true, // Validate the audience of the token (JWT)
        ValidAudience = builder.Configuration["JWT:Audience"], // Set the valid audience from the configuration

        ValidateIssuerSigningKey = true, // Ensure that the token is signed with a valid key
        IssuerSigningKey = new SymmetricSecurityKey(
            // Use a symmetric security key to validate the signing key, fetched from the configuration
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

// Add swagger gen
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();