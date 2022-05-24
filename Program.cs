using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using learningSystem.Entities;
using learningSystem.Middleware;
using learningSystem.Models;
using learningSystem.Services;
using learningSystem;
using System.Reflection;
using learningSystem.Models.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//auth building jwt bearer
var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);//bind json

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//seed, 
builder.Services.AddScoped<LearningSystemSeeder>();
//services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<ICourseMainService, CourseMainService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
//errors
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

//db
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<LearningSystemDbContext>();

//open cors for testing purposes
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>
    builder.AllowAnyMethod()
           .AllowAnyHeader()
           .AllowAnyOrigin()
    );
});

var app = builder.Build();
//seeder init
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<LearningSystemSeeder>();

app.UseResponseCaching();
app.UseStaticFiles();//files
app.UseCors("FrontEndClient");

//seeding
seeder.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();//auth

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
