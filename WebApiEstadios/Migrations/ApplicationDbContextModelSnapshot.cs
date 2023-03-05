﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiEstadios;

#nullable disable

namespace WebApiEstadios.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiEstadios.Entidades.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Available")
                        .HasColumnType("bigint");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<int>("EstadioId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Taken")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EstadioId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Estadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Coords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParkingCapacity")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalSeats")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Estadios");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Area", b =>
                {
                    b.HasOne("WebApiEstadios.Entidades.Estadio", "Estadio")
                        .WithMany("Areas")
                        .HasForeignKey("EstadioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estadio");
                });

            modelBuilder.Entity("WebApiEstadios.Entidades.Estadio", b =>
                {
                    b.Navigation("Areas");
                });
#pragma warning restore 612, 618
        }
    }
}
