using HeinekenRobot.Data;
using HeinekenRobot.Repository.GiftFolder;
using HeinekenRobot.Repository.LocationFolder;
using HeinekenRobot.Repository.RecycleMachineFolder;
using HeinekenRobot.Repository.RobotFolder;
using HeinekenRobot.Service.GiftFolder;
using HeinekenRobot.Service.LocationFolder;
using HeinekenRobot.Service.RecycleMachineFolder;
using HeinekenRobot.Service.RobotFolder;
using Microsoft.EntityFrameworkCore;
using System;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeniekenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<IRobotService, RobotService>();

builder.Services.AddScoped<IRecycleMachineRepository, RecycleMachineRepository>();
builder.Services.AddScoped<IRecycleMachineService, RecycleMachineService>();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<IGiftService, GiftService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers()
//        .AddJsonOptions(options =>
//        {
//            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//        });
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

app.Run();
