﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TavernApi.Databases;

namespace TavernApi.Migrations
{
    [DbContext(typeof(TavernContext))]
    [Migration("20190915074234_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TavernApi.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TavernApi.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationTimeStamp");

                    b.Property<long?>("CreatorId");

                    b.Property<long>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TavernApi.Models.CommentNode", b =>
                {
                    b.Property<long>("ParentId");

                    b.Property<long>("ChildId");

                    b.HasKey("ParentId", "ChildId");

                    b.HasIndex("ChildId")
                        .IsUnique();

                    b.ToTable("CommentNodes");
                });

            modelBuilder.Entity("TavernApi.Models.Function", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("TavernApi.Models.Identity.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TavernApi.Models.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TavernApi.Models.Identity.UserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TavernApi.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CategoryId");

                    b.Property<DateTime>("CreationTimeStamp");

                    b.Property<long?>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TavernApi.Models.ProjectFunction", b =>
                {
                    b.Property<long>("ProjectId");

                    b.Property<long>("FunctionId");

                    b.HasKey("ProjectId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("ProjectFunctions");
                });

            modelBuilder.Entity("TavernApi.Models.Comment", b =>
                {
                    b.HasOne("TavernApi.Models.Identity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("TavernApi.Models.CommentNode", b =>
                {
                    b.HasOne("TavernApi.Models.Comment", "Child")
                        .WithOne("Parent")
                        .HasForeignKey("TavernApi.Models.CommentNode", "ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TavernApi.Models.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TavernApi.Models.Identity.UserRole", b =>
                {
                    b.HasOne("TavernApi.Models.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TavernApi.Models.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TavernApi.Models.Project", b =>
                {
                    b.HasOne("TavernApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("TavernApi.Models.Identity.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("TavernApi.Models.ProjectFunction", b =>
                {
                    b.HasOne("TavernApi.Models.Function", "Function")
                        .WithMany("Projects")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TavernApi.Models.Project", "Project")
                        .WithMany("Functions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
