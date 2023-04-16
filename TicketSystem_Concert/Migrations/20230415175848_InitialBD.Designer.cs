﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSystem_Concert.DAL;

#nullable disable

namespace TicketSystem_Concert.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230415175848_InitialBD")]
    partial class InitialBD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketSystem_Concert.DAL.Entities.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EntranceGate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UseData")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
