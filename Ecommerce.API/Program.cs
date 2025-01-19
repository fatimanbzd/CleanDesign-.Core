
using System.Text;
using Ecommerce.API.IServices;
using Ecommerce.API.services;
using Ecommerce.Core.Repositories;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Repositpries;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<EcommerceDbContext>(
               x => x.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("EcommerceDomain",
    policy => policy.WithOrigins("*")
    .AllowAnyHeader()
    .AllowAnyMethod());
});



var app = builder.Build();
app.UseDeveloperExceptionPage();
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseCors("EcommerceDomain");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
