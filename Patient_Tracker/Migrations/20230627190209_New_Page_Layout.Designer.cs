﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patient_Tracker.Data;

#nullable disable

namespace Patient_Tracker.Migrations
{
    [DbContext(typeof(Patient_Tracker_Context))]
    [Migration("20230627190209_New_Page_Layout")]
    partial class New_Page_Layout
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Patient_Tracker.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Patient_Tracker.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalHistory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}