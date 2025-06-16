using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Opslagsværk_API.Data;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Repositories;
using Opslagsværk_API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- DATABASE ---
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer("Server=LT06485\\SQLEXPRESS;Database=OpslagsDatabase;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"));

// --- DEPENDENCY INJECTION ---
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IAssignment, AssignmentRepository>();
builder.Services.AddScoped<ICategories, CategoryRepository>();
builder.Services.AddScoped<IAssignmentCategories, AssignmentCategoryRepository>();
builder.Services.AddScoped<JwtGenerator>();
builder.Services.AddScoped<CloudinaryService>();

// --- JWT AUTH CONFIG ---
var jwtKey = "StarWarsFeaturingWalterWhiteAndSkylerYo69";
var jwtIssuer = "itsBritneyBitch";
var jwtAudience = "youGuysss";

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    });

// --- CORS CONFIGURATION ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:5128")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --- SWAGGER CONFIG ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Opslagsværk API", Version = "v1" });

    // JWT support in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {your token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// --- MIDDLEWARE ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// **Add CORS before authentication/authorization**
app.UseCors("AllowFrontend");
app.UseCors("AllowBlazorDevClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
