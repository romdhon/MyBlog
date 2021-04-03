﻿// <auto-generated />
using Blogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blogger.Migrations
{
    [DbContext(typeof(ColorContext))]
    [Migration("20210403101519_dbtest")]
    partial class dbtest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Blogger.Models.Color", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColorName")
                        .HasColumnType("TEXT");

                    b.HasKey("ColorID");

                    b.ToTable("ColorItems");
                });
#pragma warning restore 612, 618
        }
    }
}