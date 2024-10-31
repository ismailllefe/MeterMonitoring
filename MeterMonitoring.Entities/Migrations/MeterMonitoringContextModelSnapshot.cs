﻿// <auto-generated />
using System;
using DatabaseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseLibrary.Migrations
{
    [DbContext(typeof(MeterMonitoringContext))]
    partial class MeterMonitoringContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DatabaseLibrary.Models.MeterData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Current")
                        .HasColumnType("double precision");

                    b.Property<double>("LastIndex")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ReadingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Voltage")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("MeterDatas", "Main");
                });
#pragma warning restore 612, 618
        }
    }
}
