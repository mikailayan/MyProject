﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MikoBussDataAccessLayer.Concrete;

namespace MikoBussDataAccessLayer.Migrations
{
    [DbContext(typeof(MikoBussContext))]
    [Migration("20220516082358_mig-1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("MikoBussEntityLayer.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityTesisName1")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityTesisName2")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityTesisName3")
                        .HasColumnType("TEXT");

                    b.Property<string>("CiytName")
                        .HasColumnType("TEXT");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MikoBussEntityLayer.Guzergah", b =>
                {
                    b.Property<int>("GuzergahId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("GuzargahFiyat")
                        .HasColumnType("TEXT");

                    b.Property<string>("GuzergahEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("GuzergahStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("GuzergahTarihi")
                        .HasColumnType("TEXT");

                    b.HasKey("GuzergahId");

                    b.ToTable("Guzergahs");
                });

            modelBuilder.Entity("MikoBussEntityLayer.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuzergahId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketNereden")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketNereye")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketSeatNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TicketSurname")
                        .HasColumnType("TEXT");

                    b.HasKey("TicketId");

                    b.HasIndex("GuzergahId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MikoBussEntityLayer.Ticket", b =>
                {
                    b.HasOne("MikoBussEntityLayer.Guzergah", "Guzergah")
                        .WithMany("Tickets")
                        .HasForeignKey("GuzergahId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guzergah");
                });

            modelBuilder.Entity("MikoBussEntityLayer.Guzergah", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
