using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoguePalaceAPI.DBContext;
using RoguePalaceAPI.Models;
using RoguePalaceAPI.Repositories;
using RoguePalaceAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddIdentity<User, Roles>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
    .AddEntityFrameworkStores<RoguePalaceDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepositories, UserRepositories>();
builder.Services.AddScoped<IGroupeRepositories, GroupeRepositories>();
builder.Services.AddScoped<ICharacterRepositories, CharacterRepositories>();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

builder.Services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

builder.Services.AddAuth(jwtSettings);

builder.Services.AddDbContext<RoguePalaceDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuth();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
