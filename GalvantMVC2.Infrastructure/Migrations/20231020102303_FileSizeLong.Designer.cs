﻿// <auto-generated />
using System;
using GalvantMVC2.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalvantMVC2.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231020102303_FileSizeLong")]
    partial class FileSizeLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Crane", b =>
                {
                    b.Property<int>("CraneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CraneId"));

                    b.Property<DateTime?>("ElectricalExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LiftingCapacity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RaisingHeight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("ResursDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UDTExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UDTNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("WorkloadGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CraneId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Cranes");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartamentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("Location1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Location2Id")
                        .HasColumnType("int");

                    b.Property<string>("Location3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.HasIndex("Location2Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.HasKey("FileId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Forklift", b =>
                {
                    b.Property<int>("ForkliftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ForkliftId"));

                    b.Property<DateTime?>("ElectricalExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LiftingCapacity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RaisingHeight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("ResursDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UDTExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UDTNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("ForkliftId");

                    b.HasIndex("EquipmentId")
                        .IsUnique();

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Gantry", b =>
                {
                    b.Property<int>("GantryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GantryId"));

                    b.Property<DateTime?>("ElectricalExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LiftingCapacity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RaisingHeight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("Range")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("ResursDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UDTExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UDTNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("WorkloadGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GantryId");

                    b.HasIndex("EquipmentId")
                        .IsUnique();

                    b.ToTable("Gantries");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Hoist", b =>
                {
                    b.Property<int>("HoistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoistId"));

                    b.Property<DateTime?>("ElectricalExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LiftingCapacity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RaisingHeight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("ResursDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UDTExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UDTNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("WorkloadGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HoistId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Hoists");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Location2", b =>
                {
                    b.Property<int>("Location2Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Location2Id"));

                    b.Property<string>("Location2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location2Id");

                    b.ToTable("Location2s");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Tank", b =>
                {
                    b.Property<int>("TankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TankId"));

                    b.Property<decimal?>("Capacity")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime?>("ElectricalExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<string>("FactoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PermissiblePressure")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResursDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UDTExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UDTNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TankId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Tanks");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("TagId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Crane", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Employee", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("GalvantMVC2.Domain.Model.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Equipment", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Location2", "Location")
                        .WithMany("Equipment")
                        .HasForeignKey("Location2Id");

                    b.HasOne("GalvantMVC2.Domain.Model.Type", "Type")
                        .WithMany("Equipment")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.File", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Category", "Category")
                        .WithMany("Files")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithMany("Files")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Forklift", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithOne("Forklift")
                        .HasForeignKey("GalvantMVC2.Domain.Model.Forklift", "EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Gantry", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithOne("Gantry")
                        .HasForeignKey("GalvantMVC2.Domain.Model.Gantry", "EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Hoist", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Tank", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Task", b =>
                {
                    b.HasOne("GalvantMVC2.Domain.Model.Tag", "Tag")
                        .WithMany("Tasks")
                        .HasForeignKey("TagId");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Category", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Equipment", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Forklift")
                        .IsRequired();

                    b.Navigation("Gantry")
                        .IsRequired();
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Location2", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Tag", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GalvantMVC2.Domain.Model.Type", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
