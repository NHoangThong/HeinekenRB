using HeinekenRobot.Data;
using HeinekenRobot.Repository.CampaignFolder;
using HeinekenRobot.Repository.GiftFolder;
using HeinekenRobot.Repository.LocationFolder;
using HeinekenRobot.Repository.RecycleMachineFolder;
using HeinekenRobot.Repository.RegionFolder;
using HeinekenRobot.Repository.RewardRuleFolder;
using HeinekenRobot.Repository.RobotFolder;
using HeinekenRobot.Repository.RoleFolder;
using HeinekenRobot.Repository.UserFolder;
using HeinekenRobot.Service.CampaignFolder;
using HeinekenRobot.Service.GiftFolder;
using HeinekenRobot.Service.LocationFolder;
using HeinekenRobot.Service.RecycleMachineFolder;
using HeinekenRobot.Service.RegionFolder;
using HeinekenRobot.Service.RewardRuleFolder;
using HeinekenRobot.Service.RobotFolder;
using HeinekenRobot.Service.RoleFolder;
using HeinekenRobot.Service.UserFolder;
using Microsoft.EntityFrameworkCore;
using System;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeniekenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

//Robot
builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<IRobotService, RobotService>();

//Recycle
builder.Services.AddScoped<IRecycleMachineRepository, RecycleMachineRepository>();
builder.Services.AddScoped<IRecycleMachineService, RecycleMachineService>();

//Location
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

//Gift
builder.Services.AddScoped<IGiftRepository, GiftRepository>();
builder.Services.AddScoped<IGiftService, GiftService>();

//RewardRule
builder.Services.AddScoped<IRewardRuleRepository, RewardRuleRepository>();
builder.Services.AddScoped<IRewardRuleService, RewardRuleService>();

//Campaign
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignService, CampaignService>();

//Region
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Role
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

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
