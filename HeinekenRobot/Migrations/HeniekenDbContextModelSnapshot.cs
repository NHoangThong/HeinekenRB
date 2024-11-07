﻿// <auto-generated />
using System;
using HeinekenRobot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeinekenRobot.Migrations
{
    [DbContext(typeof(HeniekenDbContext))]
    partial class HeniekenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HeinekenRobot.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignId");

                    b.HasIndex("RegionId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("HeinekenRobot.Models.CampaignRobotMachine", b =>
                {
                    b.Property<int>("CampaignRobotMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignRobotMachineId"), 1L, 1);

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignRobotMachineId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("LocationId");

                    b.HasIndex("MachineId");

                    b.HasIndex("RobotId");

                    b.ToTable("CampaignRobotMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointsBalance")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiftId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpiredCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedeemedCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.HasKey("GiftId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("HeinekenRobot.Models.GiftRedemption", b =>
                {
                    b.Property<int>("RedemptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RedemptionId"), 1L, 1);

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<string>("QrCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RedeemedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RedemptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RedemptionId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("GiftRedemptions");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.HasIndex("RegionId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RecycleMachine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MachineId"), 1L, 1);

                    b.Property<string>("ContainerStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("MachineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MachineId");

                    b.HasIndex("LocationId");

                    b.ToTable("RecycleMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"), 1L, 1);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RewardRule", b =>
                {
                    b.Property<int>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RuleId"), 1L, 1);

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<decimal>("GiftChance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("PointRangeMax")
                        .HasColumnType("int");

                    b.Property<int>("PointRangeMin")
                        .HasColumnType("int");

                    b.HasKey("RuleId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("GiftId");

                    b.ToTable("RewardRules");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Robot", b =>
                {
                    b.Property<int>("RobotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RobotId"), 1L, 1);

                    b.Property<int>("BatteryLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccessTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("RobotName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RobotTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RobotId");

                    b.HasIndex("LocationId");

                    b.HasIndex("RobotTypeId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RobotType", b =>
                {
                    b.Property<string>("RobotTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RobotTypeId");

                    b.ToTable("RobotType");

                    b.HasData(
                        new
                        {
                            RobotTypeId = "1",
                            TypeName = "Silverbot"
                        },
                        new
                        {
                            RobotTypeId = "2",
                            TypeName = "DeliveryBox"
                        });
                });

            modelBuilder.Entity("HeinekenRobot.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId1")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("GiftId");

                    b.HasIndex("LocationId");

                    b.HasIndex("MachineId");

                    b.HasIndex("RobotId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("HeinekenRobot.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Campaign", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("HeinekenRobot.Models.CampaignRobotMachine", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Campaign", "Campaign")
                        .WithMany("CampaignRobotMachines")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Location", "Location")
                        .WithMany("CampaignRobotMachines")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.RecycleMachine", "Machine")
                        .WithMany("CampaignRobotMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Robot", "Robot")
                        .WithMany("CampaignRobotMachines")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Location");

                    b.Navigation("Machine");

                    b.Navigation("Robot");
                });

            modelBuilder.Entity("HeinekenRobot.Models.GiftRedemption", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Location", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Region", "Region")
                        .WithMany("Locations")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RecycleMachine", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RewardRule", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Robot", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.RobotType", "RobotType")
                        .WithMany("Robots")
                        .HasForeignKey("RobotTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("RobotType");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Transaction", b =>
                {
                    b.HasOne("HeinekenRobot.Models.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Customer", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("HeinekenRobot.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.RecycleMachine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HeinekenRobot.Models.Robot", "Robot")
                        .WithMany()
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Customer");

                    b.Navigation("Gift");

                    b.Navigation("Location");

                    b.Navigation("Machine");

                    b.Navigation("Robot");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Campaign", b =>
                {
                    b.Navigation("CampaignRobotMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Location", b =>
                {
                    b.Navigation("CampaignRobotMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RecycleMachine", b =>
                {
                    b.Navigation("CampaignRobotMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Region", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("HeinekenRobot.Models.Robot", b =>
                {
                    b.Navigation("CampaignRobotMachines");
                });

            modelBuilder.Entity("HeinekenRobot.Models.RobotType", b =>
                {
                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
