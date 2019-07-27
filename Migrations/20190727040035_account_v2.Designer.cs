﻿// <auto-generated />
using System;
using MarvelLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvelLibrary.Migrations
{
    [DbContext(typeof(MarvelLibraryContext))]
    [Migration("20190727040035_account_v2")]
    partial class account_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarvelLibrary.Models.Account", b =>
                {
                    b.Property<string>("Login")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PwHash");

                    b.HasKey("Login");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("MarvelLibrary.Models.Character", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Desc");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Thumbnail");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("MarvelLibrary.Models.Comic", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Format");

                    b.Property<DateTime>("OnSaleDate");

                    b.Property<int>("PageCount");

                    b.Property<string>("SeriesName");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Comic");
                });

            modelBuilder.Entity("MarvelLibrary.Models.ComicCharacter", b =>
                {
                    b.Property<int>("ComicId");

                    b.Property<int>("CharacterId");

                    b.HasKey("ComicId", "CharacterId");

                    b.ToTable("ComicCharacter");
                });

            modelBuilder.Entity("MarvelLibrary.Models.Fav", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId");

                    b.Property<string>("AccountLogin");

                    b.HasKey("Id", "CharacterId", "AccountLogin");

                    b.ToTable("Fav");
                });
#pragma warning restore 612, 618
        }
    }
}
