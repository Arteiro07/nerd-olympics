using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using NerdOlympics.Data.Interfaces;
using NerdOlympics.Data.Repositories;
using NerdOlympicsAPI.Interfaces;
using NerdOlympicsAPI.Services;
using NerdOlympicsAPI.Services.Security;
using Custom = NerdOlympics.Data.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NerdOlympics.API.Interfaces;
using NerdOlympics.API.Services;
using NerdOlympics.Data;
using NerdOlympics.Data.Enum.Security;
using NerdOlympics.API.Services.ErrorHandling;
using NerdOlympics.API.FactoryPattern;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:NerdOlympicsDB"] ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<NerdOlympicsDBContext>(options =>
{
    options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
});

builder.Services.AddScoped<ICompetitionRepository,CompetitionRepository>();
builder.Services.AddScoped<ICompetitionsService,CompetitionsService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();

builder.Services.AddTransient<CompetitionFactory>();
builder.Services.AddScoped<IFactoryRepository, FactoryRepository>();

builder.Services.AddSingleton<IJwtTokenService,JwtTokenService>();


// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesResponseTypeAttribute(200));
    options.Filters.Add(new ProducesResponseTypeAttribute(400));
    options.Filters.Add(new ProducesResponseTypeAttribute(500));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.Authenticated, policy => policy.RequireClaim(ClaimTypes.Authenticated));
    options.AddPolicy(Policies.Admin, policy => policy.RequireClaim(ClaimTypes.Admin));
    options.AddPolicy(Policies.CompetitionAdmin, policy => policy.RequireClaim(ClaimTypes.CompetitionAdmin));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["TokenIssuer"] ?? throw new InvalidOperationException("TokenIssuerNotFound"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecret"] ?? throw new InvalidOperationException("JwtSecretNotFound")))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.Use(async (context, next) =>
{
    if (context.Request.Path.Value == "/")
    {
        context.Response.Redirect("/swagger");
    }
    else
    {
        await next();
    }
});

app.UseMiddleware<JwtMiddleware>();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors("CorsPolicy");

app.Run();
