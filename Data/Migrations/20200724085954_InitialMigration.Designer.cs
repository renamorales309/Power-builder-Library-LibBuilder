﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200724085954_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Data.Models.LibraryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Build")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Directory")
                        .HasColumnType("TEXT");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TargetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("Library");
                });

            modelBuilder.Entity("Data.Models.ObjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectType")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Regenerate")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Object");
                });

            modelBuilder.Entity("Data.Models.ProcessModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Error")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Sucess")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("Data.Models.SettingsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DarkMode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrimaryColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondaryColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DarkMode = false,
                            PrimaryColor = "teal",
                            SecondaryColor = "cyan",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Models.TargetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Directory")
                        .HasColumnType("TEXT");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkspaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("Data.Models.WorkspaceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Directory")
                        .HasColumnType("TEXT");

                    b.Property<string>("File")
                        .HasColumnType("TEXT");

                    b.Property<string>("PBVersion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Workspace");
                });

            modelBuilder.Entity("Data.Models.LibraryModel", b =>
                {
                    b.HasOne("Data.Models.TargetModel", "Target")
                        .WithMany("Librarys")
                        .HasForeignKey("TargetId");
                });

            modelBuilder.Entity("Data.Models.ObjectModel", b =>
                {
                    b.HasOne("Data.Models.LibraryModel", "Library")
                        .WithMany("Objects")
                        .HasForeignKey("LibraryId");
                });

            modelBuilder.Entity("Data.Models.ProcessModel", b =>
                {
                    b.HasOne("Data.Models.TargetModel", "Target")
                        .WithMany("Process")
                        .HasForeignKey("TargetId");
                });

            modelBuilder.Entity("Data.Models.TargetModel", b =>
                {
                    b.HasOne("Data.Models.WorkspaceModel", "Workspace")
                        .WithMany("Target")
                        .HasForeignKey("WorkspaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
