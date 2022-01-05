using Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Application.Activities;
using Application.Core;
using server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
ApplicationServiceExtensions.AddApplicationServices(builder.Services, builder.Configuration);
var app = builder.Build();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{
     var context = services.GetRequiredService<DataContext>();
     await context.Database.MigrateAsync();
     await Seed.SeedData(context);
}
catch (Exception ex)
{
     var logger = services.GetRequiredService<ILogger<Program>>();
     logger.LogError(ex, "An error occurred while migrating the database.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
