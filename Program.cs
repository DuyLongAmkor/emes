
using emes;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
       policy =>
       {
           policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
       });
});
var connectionString = builder.Configuration.GetConnectionString("Pgsql");



builder.Services.AddDbContext<EmesDbContext>(
    //options => options.UseModel(
    //options=>options.UseModel(
    options => options.UseNpgsql(connectionString)
);

//builder.Services.AddD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowFrontend");


app.MapGet("/whoami/ip", (HttpContext ctx) => {
    var xff = ctx.Request.Headers["X-Forwarded-For"].ToString();
    var remote = ctx.Connection.RemoteIpAddress?.ToString();
    var clientIp = string.IsNullOrWhiteSpace(xff) ? remote : xff.Split(',')[0].Trim();
    return Results.Json(new { ip = clientIp ?? "unknown" });
});



app.Run();
