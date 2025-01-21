
using System.Text;
using Ecommerce.API.IServices;
using Ecommerce.Application.Services;
using Ecommerce.Domain.Core.Repositories;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositpries;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

builder.Services.ConfigureInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(option =>
//{
//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});
//builder.Services.AddTransient(typeof(IUserService), typeof(UserService));

//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EcommerceDomain",
    policy => policy.WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod());
});



var app = builder.Build();
app.UseDeveloperExceptionPage();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.MigrateDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("EcommerceDomain");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
