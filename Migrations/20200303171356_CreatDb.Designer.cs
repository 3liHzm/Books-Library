﻿// <auto-generated />
using System;
using BooksLp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksLp.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20200303171356_CreatDb")]
    partial class CreatDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("BooksLp.Models.Auther", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authers");
                });

            modelBuilder.Entity("BooksLp.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AutherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tital")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksLp.Models.Books", b =>
                {
                    b.HasOne("BooksLp.Models.Auther", "Auther")
                        .WithMany()
                        .HasForeignKey("AutherId");
                });
#pragma warning restore 612, 618
        }
    }
}
