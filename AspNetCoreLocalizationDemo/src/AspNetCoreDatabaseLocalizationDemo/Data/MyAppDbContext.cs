using System;
using System.Collections.Generic;
using AspNetCoreDatabaseLocalizationDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDatabaseLocalizationDemo.Data;

public partial class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<StringResource> StringResources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Culture)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StringResource>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
