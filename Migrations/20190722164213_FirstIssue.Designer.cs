﻿// <auto-generated />
using System;
using MarvelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvelLibrary.Migrations
{
    [DbContext(typeof(MarvelLibraryContext))]
    [Migration("20190722164213_FirstIssue")]
    partial class FirstIssue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MarvelLibrary.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Thumbnail");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
