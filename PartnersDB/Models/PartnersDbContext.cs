using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PartnersDB.Models;

public partial class PartnersDbContext : DbContext
{
    public PartnersDbContext()
    {
    }

    public PartnersDbContext(DbContextOptions<PartnersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TypesOfPartner> TypesOfPartners { get; set; }

    public virtual DbSet<TypesOfProduct> TypesOfProducts { get; set; }

    public virtual DbSet<ViewPartner> ViewPartners { get; set; }

    public virtual DbSet<ViewPartnerDiscount> ViewPartnerDiscounts { get; set; }

    public virtual DbSet<ViewProduct> ViewProducts { get; set; }

    public virtual DbSet<ViewSalesHistory> ViewSalesHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=partners_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_pkey");

            entity.ToTable("partner", tb => tb.HasComment("Информация о партнерах компании"));

            entity.HasIndex(e => e.IdTypeOfPartner, "idx_partner_type");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IdTypeOfPartner).HasColumnName("id_type_of_partner");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
            entity.Property(e => e.LegalAddress)
                .HasMaxLength(255)
                .HasColumnName("legal_address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameOfDirector)
                .HasMaxLength(255)
                .HasColumnName("name_of_director");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdTypeOfPartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypeOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partner_type");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_products_pkey");

            entity.ToTable("partners_products", tb => tb.HasComment("Журнал продаж продукции партнерам"));

            entity.HasIndex(e => e.DateSelling, "idx_partners_products_date");

            entity.HasIndex(e => e.IdPartner, "idx_partners_products_partner");

            entity.HasIndex(e => e.IdProduct, "idx_partners_products_product");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DateSelling)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_selling");
            entity.Property(e => e.IdPartner).HasColumnName("id_partner");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_products_partner");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_products_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product", tb => tb.HasComment("Каталог продукции компании"));

            entity.HasIndex(e => e.IdTypeOfProduct, "idx_product_type");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.IdTypeOfProduct).HasColumnName("id_type_of_product");
            entity.Property(e => e.MinimalPrice)
                .HasColumnType("money")
                .HasColumnName("minimal_price");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.IdTypeOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_type");
        });

        modelBuilder.Entity<TypesOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("types_of_partner_pkey");

            entity.ToTable("types_of_partner", tb => tb.HasComment("Справочник типов партнеров"));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.TypeOfPartner)
                .HasMaxLength(255)
                .HasColumnName("type_of_partner");
        });

        modelBuilder.Entity<TypesOfProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("types_of_product_pkey");

            entity.ToTable("types_of_product", tb => tb.HasComment("Справочник типов продукции"));

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.TypeCoefficient)
                .HasPrecision(10, 2)
                .HasColumnName("type_coefficient");
            entity.Property(e => e.TypeOfProduct)
                .HasMaxLength(255)
                .HasColumnName("type_of_product");
        });

        modelBuilder.Entity<ViewPartner>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_partners");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
            entity.Property(e => e.LegalAddress)
                .HasMaxLength(255)
                .HasColumnName("legal_address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameOfDirector)
                .HasMaxLength(255)
                .HasColumnName("name_of_director");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TotalPurchases).HasColumnName("total_purchases");
            entity.Property(e => e.TypeOfPartner)
                .HasMaxLength(255)
                .HasColumnName("type_of_partner");
        });

        modelBuilder.Entity<ViewPartnerDiscount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_partner_discounts");

            entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TotalPurchases).HasColumnName("total_purchases");
        });

        modelBuilder.Entity<ViewProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_products");

            entity.Property(e => e.Article)
                .HasMaxLength(50)
                .HasColumnName("article");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MinimalPrice)
                .HasColumnType("money")
                .HasColumnName("minimal_price");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TotalSales).HasColumnName("total_sales");
            entity.Property(e => e.TypeOfProduct)
                .HasMaxLength(255)
                .HasColumnName("type_of_product");
        });

        modelBuilder.Entity<ViewSalesHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_sales_history");

            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DateSelling)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_selling");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(255)
                .HasColumnName("partner_name");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
