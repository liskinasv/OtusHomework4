using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace OtusHomework4;

public partial class AvitoContext : DbContext
{
    public AvitoContext()
    {
    }

    public AvitoContext(DbContextOptions<AvitoContext> options)
        : base(options)
    {
       // Database.EnsureCreated();
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        string? connectionString = config.GetConnectionString("db");

        optionsBuilder.UseNpgsql(connectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("advertisements_pkey");

            entity.ToTable("advertisements");

            entity.Property(e => e.AdId).HasColumnName("ad_id");
            entity.Property(e => e.AdId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("advertisements_subcategory_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("advertisements_user_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey"); 

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("subcategory_pkey");

            entity.ToTable("subcategory");

            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id").ValueGeneratedOnAdd(); ;
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Subcategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("subcategory_category_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey") ;

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id").ValueGeneratedOnAdd() ;
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
