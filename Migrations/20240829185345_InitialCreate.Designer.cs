﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using client_contact_management_system.Models;

#nullable disable

namespace client_contact_management_system.Migrations
{
    [DbContext(typeof(ClientContactManagementContext))]
    [Migration("20240829185345_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("client_contact_management_system.Models.ClientViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Contacts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("client_contact_management_system.Models.ContactViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Clients")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("client_contact_management_system.Models.Linked", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClietId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("linkeds");
                });
#pragma warning restore 612, 618
        }
    }
}
