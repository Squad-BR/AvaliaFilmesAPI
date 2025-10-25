

using AvaliaFilmesAPI.Data.Context;
using AvaliaFilmesAPI.Domain;
using AvaliaFilmesAPI.Web; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;




using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Business.Service;
using AvaliaFilmesAPI.Data.Context;
using AvaliaFilmesAPI.Data.Repositories;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.Cookie.Name = "AvaliaFilmes.AuthCookie";
    options.Cookie.SameSite = SameSiteMode.None; 
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 

    
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
    });
});


//Escopo do rpositório
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//Escopo do serviço
builder.Services.AddScoped<IFilmeService, FilmeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowReactApp");

app.UseAuthentication(); 

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        
        await IdentityDataSeeder.SeedDataAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro durante o seeding do banco de dados.");
    }
}

app.Run();