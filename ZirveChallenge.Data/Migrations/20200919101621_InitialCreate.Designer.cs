﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZirveChallenge.Data;

namespace ZirveChallenge.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200919101621_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZirveChallenge.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ISDeleted = false,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            ISDeleted = false,
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("ZirveChallenge.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("ISDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("InnerBarcode")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ISDeleted = false,
                            Name = "Pilot Kalem",
                            Price = 12.50m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            ISDeleted = false,
                            Name = "Kurşun Kalem",
                            Price = 40.50m,
                            Stock = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            ISDeleted = false,
                            Name = "Tükenmez Kalem",
                            Price = 500.50m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ISDeleted = false,
                            Name = "Küçük boy defter",
                            Price = 10.50m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            ISDeleted = false,
                            Name = "Orta boy defter",
                            Price = 10.50m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            ISDeleted = false,
                            Name = "Büyük boy defter",
                            Price = 10.50m,
                            Stock = 300
                        });
                });

            modelBuilder.Entity("ZirveChallenge.Core.Entities.Product", b =>
                {
                    b.HasOne("ZirveChallenge.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
