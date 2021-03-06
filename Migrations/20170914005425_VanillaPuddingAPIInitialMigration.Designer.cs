﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VanillaPuddingAPI.DAL;

namespace VanillaPuddingAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170914005425_VanillaPuddingAPIInitialMigration")]
    partial class VanillaPuddingAPIInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("VanillaPuddingAPI.DAL.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
