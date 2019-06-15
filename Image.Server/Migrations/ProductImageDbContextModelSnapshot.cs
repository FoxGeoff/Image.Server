﻿// <auto-generated />
using System;
using Image.Server.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Image.Server.Migrations
{
    [DbContext(typeof(ProductImageDbContext))]
    partial class ProductImageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Image.Server.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Image.Server.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AdditionalCost");

                    b.Property<string>("AiPartNumber");

                    b.Property<int?>("Category")
                        .HasColumnName("AssociatedCategoryId");

                    b.Property<double?>("Cost");

                    b.Property<int>("CostVerification")
                        .HasColumnName("CostVerificationBy");

                    b.Property<double?>("DefaultPriority");

                    b.Property<byte>("Discontinued")
                        .HasColumnName("IsDiscontinued");

                    b.Property<sbyte>("ExcludedDesAiNum")
                        .HasColumnName("IsExcludedDesAinumOverrwrite");

                    b.Property<int?>("Group")
                        .HasColumnName("AssociatedGroupId");

                    b.Property<int?>("Image")
                        .HasColumnName("AssociatedImageId");

                    b.Property<string>("ItemsAssociated");

                    b.Property<string>("ManufactureName");

                    b.Property<string>("ManufactureNumber");

                    b.Property<string>("MerchantNumber");

                    b.Property<string>("MfgManualUrl");

                    b.Property<string>("MfgUrl");

                    b.Property<int?>("PrimaryVendor")
                        .HasColumnName("AssociatedPrimaryVendorId");

                    b.Property<string>("ProductDescription");

                    b.Property<byte>("RecycleFee")
                        .HasColumnName("IsRecycleFee");

                    b.Property<int?>("RecycleNumber")
                        .HasColumnName("AssociatedRecycleId");

                    b.Property<double?>("Retail");

                    b.Property<int?>("Screen")
                        .HasColumnName("AssociatedScreenId");

                    b.Property<int?>("SecondaryVendor")
                        .HasColumnName("AssociatedSecondaryVendorId");

                    b.Property<int?>("Snapshot")
                        .HasColumnName("AssociatedSnapshotTypeId");

                    b.Property<byte?>("Taxable")
                        .HasColumnName("IsTaxable");

                    b.Property<int?>("TertiaryVendor")
                        .HasColumnName("AssociatedTertiaryVendorId");

                    b.HasKey("Id");

                    b.HasIndex("Image");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Image.Server.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<string>("FileName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("ImageFull")
                        .HasMaxLength(150000);

                    b.Property<byte[]>("ImageThumb")
                        .HasMaxLength(50000);

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Image.Server.Entities.Product", b =>
                {
                    b.HasOne("Image.Server.Entities.ProductImage", "ProductImage")
                        .WithMany("Products")
                        .HasForeignKey("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
