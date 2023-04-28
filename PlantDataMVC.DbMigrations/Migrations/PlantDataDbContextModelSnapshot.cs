﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantDataMVC.Entities.Context;

#nullable disable

namespace PlantDataMVC.DbMigrations.Migrations
{
    [DbContext(typeof(PlantDataDbContext))]
    partial class PlantDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.GenusEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("LatinName");

                    b.HasKey("Id");

                    b.ToTable("Genus", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.JournalEntryEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JournalEntryTypeId")
                        .HasColumnType("int")
                        .HasColumnName("JournalEntryTypeId");

                    b.Property<string>("Notes")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Notes");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ProductTypeId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int?>("SeedTrayId")
                        .HasColumnType("int")
                        .HasColumnName("SeedTrayId");

                    b.Property<string>("Source")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Source");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int")
                        .HasColumnName("SpeciesId");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("date")
                        .HasColumnName("TransactionDate");

                    b.HasKey("Id");

                    b.HasIndex("JournalEntryTypeId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SeedTrayId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("JournalEntry", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.JournalEntryTypeEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Effect")
                        .HasColumnType("int")
                        .HasColumnName("Effect");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("JournalEntryType", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.PlantStockEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ProductTypeId");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int")
                        .HasColumnName("QuantityInStock");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int")
                        .HasColumnName("SpeciesId");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("PlantStock", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.PriceListTypeEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Kind");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("PriceListType", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.ProductPriceEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BarcodeSKU")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar")
                        .HasColumnName("BarcodeSKU");

                    b.Property<DateTime>("DateEffective")
                        .HasColumnType("date")
                        .HasColumnName("DateEffective");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int>("PriceListTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PriceListTypeId");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ProductTypeId");

                    b.HasKey("Id");

                    b.HasAlternateKey("PriceListTypeId", "ProductTypeId", "DateEffective")
                        .HasName("AK_ProductPrice_ProductType_PriceListType_Date");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductPrice", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductType", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SaleEventEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Location");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("SaleDate")
                        .HasColumnType("date")
                        .HasColumnName("SaleDate");

                    b.HasKey("Id");

                    b.ToTable("SaleEvent", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SaleEventStockEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ProductTypeId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int>("SaleEventId")
                        .HasColumnType("int")
                        .HasColumnName("SaleEventId");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int")
                        .HasColumnName("SpeciesId");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("SaleEventId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("SaleEventStock", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedBatchEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCollected")
                        .HasColumnType("date")
                        .HasColumnName("DateCollected");

                    b.Property<bool>("Emptied")
                        .HasColumnType("bit")
                        .HasColumnName("Emptied");

                    b.Property<string>("Location")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Location");

                    b.Property<string>("Notes")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Notes");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int")
                        .HasColumnName("SiteId");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int")
                        .HasColumnName("SpeciesId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("SeedBatch", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedTrayEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatePlanted")
                        .HasColumnType("date")
                        .HasColumnName("DatePlanted");

                    b.Property<int>("SeedBatchId")
                        .HasColumnType("int")
                        .HasColumnName("SeedBatchId");

                    b.Property<bool>("ThrownOut")
                        .HasColumnType("bit")
                        .HasColumnName("ThrownOut");

                    b.Property<string>("Treatment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Treatment");

                    b.HasKey("Id");

                    b.HasIndex("SeedBatchId");

                    b.ToTable("SeedTray", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SiteEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal")
                        .HasColumnName("Latitude");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal")
                        .HasColumnName("Longitude");

                    b.Property<string>("SiteName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("SiteName");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Suburb");

                    b.HasKey("Id");

                    b.ToTable("Site", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommonName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("CommonName");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Description");

                    b.Property<int>("GenusId")
                        .HasColumnType("int")
                        .HasColumnName("GenusId");

                    b.Property<bool>("Native")
                        .HasColumnType("bit")
                        .HasColumnName("Native");

                    b.Property<int?>("PropagationTime")
                        .HasColumnType("int")
                        .HasColumnName("PropagationTime");

                    b.Property<string>("SpecificName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar")
                        .HasColumnName("SpecificName");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.ToTable("Species", "dbo");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.JournalEntryEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.JournalEntryTypeEntityModel", "JournalEntryType")
                        .WithMany("JournalEntries")
                        .HasForeignKey("JournalEntryTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SeedTrayEntityModel", "SeedTray")
                        .WithMany("JournalEntries")
                        .HasForeignKey("SeedTrayId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JournalEntryType");

                    b.Navigation("ProductType");

                    b.Navigation("SeedTray");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.PlantStockEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", "ProductType")
                        .WithMany("PlantStocks")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", "Species")
                        .WithMany("PlantStocks")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.ProductPriceEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.PriceListTypeEntityModel", "PriceListType")
                        .WithMany("ProductPrices")
                        .HasForeignKey("PriceListTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", "ProductType")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PriceListType");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SaleEventStockEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SaleEventEntityModel", "SaleEvent")
                        .WithMany("SaleEventStock")
                        .HasForeignKey("SaleEventId")
                        .IsRequired()
                        .HasConstraintName("FK_SaleEventStock_SaleEvent");

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");

                    b.Navigation("SaleEvent");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedBatchEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.SiteEntityModel", "Site")
                        .WithMany("SeedBatches")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", "Species")
                        .WithMany("SeedBatches")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedTrayEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.SeedBatchEntityModel", "SeedBatch")
                        .WithMany("SeedTrays")
                        .HasForeignKey("SeedBatchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SeedBatch");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", b =>
                {
                    b.HasOne("PlantDataMVC.Entities.EntityModels.GenusEntityModel", "Genus")
                        .WithMany("Species")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Genus");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.GenusEntityModel", b =>
                {
                    b.Navigation("Species");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.JournalEntryTypeEntityModel", b =>
                {
                    b.Navigation("JournalEntries");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.PriceListTypeEntityModel", b =>
                {
                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.ProductTypeEntityModel", b =>
                {
                    b.Navigation("PlantStocks");

                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SaleEventEntityModel", b =>
                {
                    b.Navigation("SaleEventStock");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedBatchEntityModel", b =>
                {
                    b.Navigation("SeedTrays");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SeedTrayEntityModel", b =>
                {
                    b.Navigation("JournalEntries");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SiteEntityModel", b =>
                {
                    b.Navigation("SeedBatches");
                });

            modelBuilder.Entity("PlantDataMVC.Entities.EntityModels.SpeciesEntityModel", b =>
                {
                    b.Navigation("PlantStocks");

                    b.Navigation("SeedBatches");
                });
#pragma warning restore 612, 618
        }
    }
}