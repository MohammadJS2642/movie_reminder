﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace MovieReminderAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20210722100805_MovieModelsAdded")]
    partial class MovieModelsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("MovieTableDLL.Models.MovieModels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("MovieAddedDdate")
                        .HasColumnType("datetime");

                    b.Property<string>("MovieName")
                        .HasColumnType("text");

                    b.Property<DateTime>("MovieReleaseDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("MovieModels");
                });

            modelBuilder.Entity("SignupAndLoginDLL.Models.UsersModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("UsersModels");
                });
#pragma warning restore 612, 618
        }
    }
}
