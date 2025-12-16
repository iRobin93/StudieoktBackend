using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudieøktBackend.Data;
using StudieøktBackend.Mapping;
using StudieøktBackend.Repositories;
using StudieøktBackend.Repositories.Interfaces;
using StudieøktBackend.Services;
using StudieøktBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// MySQL connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))));

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173",
        "https://irobin93.github.io/StudieoktFrontend/")

              .AllowAnyHeader()
              .AllowAnyMethod());
});


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



/* nuget console commands
 * sqllocaldb create local  -  i CMD vindu først.
 * Lage database:
 * Add-Migration MySQLInitialMigration
 * Update-Database
 * 
 * Rense:
 * Drop-Database 
 * Remove-Migration 
 */
