﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Inventory.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConnectionPoint.Inventory.Infrastructure.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("inventory")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct", "inventory");
                });

            modelBuilder.Entity("CategoryService", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServicesId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("CategoryService", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("text");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("text");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameAr")
                        .HasColumnType("text");

                    b.Property<string>("NameEn")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Deal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<IList<Day>>("AvailableOn")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<bool>("AvailableOnShop")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("DiscountType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndsOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("NetPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("PerUserLimit")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartsOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TaxesIds")
                        .HasColumnType("jsonb");

                    b.Property<int>("TotalLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AvailableOn");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("AvailableOn"), "gin");

                    b.HasIndex("DealId");

                    b.ToTable("Deals", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<bool>("AvailableOnShop")
                        .HasColumnType("boolean");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("DiscountType")
                        .HasColumnType("integer");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("NetPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("ParentProduct")
                        .HasColumnType("uuid");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer");

                    b.Property<string>("TaxesIds")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.ToTable("Products", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductAttributes", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductAttributeValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductAttributeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductAttributeId");

                    b.ToTable("ProductAttributeValue", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductUnitQuantity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uuid");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.HasKey("ProductId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ProductUnitQuantities", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductVariation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariations", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<bool>("AvailableOnShop")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("DiscountType")
                        .HasColumnType("integer");

                    b.Property<string>("EmployeesIds")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GrossPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameAr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("NetPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("ServiceType")
                        .HasColumnType("integer");

                    b.Property<string>("TaxesIds")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.ToTable("Services", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ServiceProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceProduct", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Units", "inventory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Variation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductVariationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ValueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductVariationId");

                    b.HasIndex("ValueId");

                    b.ToTable("Variations", "inventory");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryService", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Category", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Deal", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Deal", null)
                        .WithMany("Deals")
                        .HasForeignKey("DealId");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Product", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Deal", null)
                        .WithMany("Products")
                        .HasForeignKey("DealId");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductAttributeValue", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.ProductAttribute", "ProductAttribute")
                        .WithMany("Values")
                        .HasForeignKey("ProductAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductUnitQuantity", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Product", null)
                        .WithMany("ProductUnitQuantities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Unit", null)
                        .WithMany("ProductUnitQuantities")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductVariation", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Product", "Product")
                        .WithMany("Variations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Service", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Deal", null)
                        .WithMany("Services")
                        .HasForeignKey("DealId");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ServiceProduct", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.Service", "Service")
                        .WithMany("ServiceProducts")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Variation", b =>
                {
                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.ProductAttribute", "Attribute")
                        .WithMany("Variations")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.ProductVariation", "ProductVariation")
                        .WithMany("Variations")
                        .HasForeignKey("ProductVariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnectionPoint.Inventory.Domain.Entities.ProductAttributeValue", "Value")
                        .WithMany("Variations")
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("ProductVariation");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Deal", b =>
                {
                    b.Navigation("Deals");

                    b.Navigation("Products");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductUnitQuantities");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductAttribute", b =>
                {
                    b.Navigation("Values");

                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductAttributeValue", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.ProductVariation", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Service", b =>
                {
                    b.Navigation("ServiceProducts");
                });

            modelBuilder.Entity("ConnectionPoint.Inventory.Domain.Entities.Unit", b =>
                {
                    b.Navigation("ProductUnitQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
