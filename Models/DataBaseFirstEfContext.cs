using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiCRUDSwagger.Models;

public partial class DataBaseFirstEfContext : DbContext
{
    public DataBaseFirstEfContext()
    {
    }

    public DataBaseFirstEfContext(DbContextOptions<DataBaseFirstEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dbfirstapprtbl> Dbfirstapprtbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dbfirstapprtbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dbfirstapprtbl");

            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
