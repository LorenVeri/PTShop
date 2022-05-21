﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PTShop.Models
{
    public partial class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductMedium> ProductMedia { get; set; } = null!;
        public virtual DbSet<ProductPrice> ProductPrices { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-AMJ7HPS;Database=PTSHOP;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_User");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.Uri).HasColumnName("uri");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Country_1");

                entity.ToTable("Country");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.MadeIn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("madeIn");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Sale).HasColumnName("sale");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("update_at");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.MadeInNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MadeIn)
                    .HasConstraintName("FK_Product_Country1");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Suggests)
                    .UsingEntity<Dictionary<string, object>>(
                        "SuggestProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_suggest_product_Product2"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("SuggestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_suggest_product_Product3"),
                        j =>
                        {
                            j.HasKey("ProductId", "SuggestId");

                            j.ToTable("suggest_product");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<int>("SuggestId").HasColumnName("suggest_id");
                        });

                entity.HasMany(d => d.Suggests)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "SuggestProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("SuggestId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_suggest_product_Product3"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_suggest_product_Product2"),
                        j =>
                        {
                            j.HasKey("ProductId", "SuggestId");

                            j.ToTable("suggest_product");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<int>("SuggestId").HasColumnName("suggest_id");
                        });
            });

            modelBuilder.Entity<ProductMedium>(entity =>
            {
                entity.ToTable("Product_Media");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Uri).HasColumnName("uri");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMedia)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_Media_Product1");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("Product_Price");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_Price_Product1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Faeces).HasColumnName("faeces");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
