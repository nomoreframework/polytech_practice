﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practice_7_WEB.Models;

namespace Practice_7_WEB.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210621005339_init_0")]
    partial class init_0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Practice_7_WEB.Models.Circular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("Have_Wire")
                        .HasColumnType("bit");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<string>("NameSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power_Watt")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Rev_Per_Minute")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Wire_Length_Metr")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentId");

                    b.ToTable("Circulars");
                });

            modelBuilder.Entity("Practice_7_WEB.Models.Drill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("Have_Wire")
                        .HasColumnType("bit");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<string>("NameSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power_Watt")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Rev_Per_Minute")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Wire_Length_Metr")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentId");

                    b.ToTable("Drills");
                });

            modelBuilder.Entity("Practice_7_WEB.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("Practice_7_WEB.Models.Circular", b =>
                {
                    b.HasOne("Practice_7_WEB.Models.Instrument", "Instrument")
                        .WithMany("Circulars")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("Practice_7_WEB.Models.Drill", b =>
                {
                    b.HasOne("Practice_7_WEB.Models.Instrument", "Instrument")
                        .WithMany("Drills")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("Practice_7_WEB.Models.Instrument", b =>
                {
                    b.Navigation("Circulars");

                    b.Navigation("Drills");
                });
#pragma warning restore 612, 618
        }
    }
}
