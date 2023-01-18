﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230118213059_FKCorrection1")]
    partial class FKCorrection1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommonLibrary.Models.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Channel", "dbo");
                });

            modelBuilder.Entity("CommonLibrary.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdChannel")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Messages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdChannel");

                    b.HasIndex("IdUser");

                    b.ToTable("Message", "dbo");
                });

            modelBuilder.Entity("CommonLibrary.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Theme")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("CommonLibrary.Models.Channel", b =>
                {
                    b.HasOne("CommonLibrary.Models.User", "IdUserNavigation")
                        .WithMany("Channels")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Channel_User_FK");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("CommonLibrary.Models.Message", b =>
                {
                    b.HasOne("CommonLibrary.Models.Channel", "IdChannelNavigation")
                        .WithMany("Messages")
                        .HasForeignKey("IdChannel")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Message_Channel0_FK");

                    b.HasOne("CommonLibrary.Models.User", "IdUserNavigation")
                        .WithMany("Messages")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Message_User_FK");

                    b.Navigation("IdChannelNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("CommonLibrary.Models.Channel", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CommonLibrary.Models.User", b =>
                {
                    b.Navigation("Channels");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
