using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using DealCloudBackend.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// --- 1. Registrar el DbContext y la Conexi�n a la BD ---
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// --- 2. Configurar ASP.NET Core Identity ---
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Configuraci�n de password (puedes relajarla para desarrollo)
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// --- 3. Configurar Autenticaci�n JWT (JSON Web Token) ---
var jwtSettings = configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Key"] ?? "default-key-for-development");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // True en producci�n
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// --- 4. Configurar AutoMapper ---
// Le dice a AutoMapper que busque perfiles en el ensamblado donde vive MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// --- 5. Configurar CORS (Cross-Origin Resource Sharing) ---
// Permite que tu frontend (en otro dominio) llame a esta API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


// --- 6. Registrar Servicios Est�ndar de API ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// --- 7. Configurar Swagger para que use el Token JWT ---
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DealCloud API", Version = "v1" });

    // Definici�n de Seguridad (Bearer JWT)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticaci�n JWT usando el esquema Bearer. \r\n\r\n " +
                      "Ingresa 'Bearer' [espacio] y luego tu token en el input de texto de abajo." +
                      "\r\n\r\nEjemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Requerimiento de Seguridad
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// --- 8. Inyectar HttpContextAccessor ---
// (Opcional, pero �til para servicios que necesitan saber sobre el usuario actual)
builder.Services.AddHttpContextAccessor();

//// Add services to the container.
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// --- 9. Configurar el Pipeline de HTTP ---
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DealCloud API v1"));
}

app.UseHttpsRedirection();

app.UseRouting(); // El orden importa

app.UseCors("AllowAllOrigins"); // Aplicar la pol�tica CORS

app.UseAuthentication(); // 1ro: �Qui�n eres?
app.UseAuthorization();  // 2do: �Qu� tienes permiso de hacer?


app.MapControllers();

// --- 10. (Opcional pero Recomendado) Sembrar la Base de Datos ---
// Esto crea el rol "Admin" y un usuario admin la primera vez que corre
await SeedDatabase(app);

// --- 11. Correr la AplicACI�N ---
app.Run();

// --- M�todo Helper para Sembrar la BD ---
async Task SeedDatabase(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Aplicar migraciones pendientes (crea la BD si no existe)
            await context.Database.MigrateAsync();

            // Ahora, sembrar los datos
            await SeedData.Initialize(services, userManager, roleManager);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "Ocurri� un error al sembrar la base de datos.");
        }
    }
}