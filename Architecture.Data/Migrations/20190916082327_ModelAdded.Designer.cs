﻿// <auto-generated />
using System;
using Architecture.DataBase.CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Architecture.DataBase.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190916082327_ModelAdded")]
    partial class ModelAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.Action", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActinName");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.Module", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("ModuleName");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.ModuleAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ActionId");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<long>("ModuleId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("ModuleAction");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("RoleName");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.RoleModuleAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<long>("ModuleActionId");

                    b.Property<long>("RoleId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("RoleModuleAction");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("LastName");

                    b.Property<string>("LoginAttempt");

                    b.Property<string>("Password");

                    b.Property<string>("ProfilePic");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<long>("RoleId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Architecture.DataBase.CodeFirst.UserRoleModuleAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("CreatedUTCDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsApproved");

                    b.Property<long>("RoleModuleAction");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime?>("UpdatedUTCDate");

                    b.Property<long>("UserRoleId");

                    b.HasKey("Id");

                    b.ToTable("UserRoleModuleAction");
                });
#pragma warning restore 612, 618
        }
    }
}
