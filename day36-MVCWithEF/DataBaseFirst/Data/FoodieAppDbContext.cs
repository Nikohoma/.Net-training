using System;
using System.Collections.Generic;
using DataBaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Data;

public partial class FoodieAppDbContext : DbContext
{
    public FoodieAppDbContext()
    {
    }

    public FoodieAppDbContext(DbContextOptions<FoodieAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employees> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SSN\\SQLEXPRESS;Database=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11BD2E1A0E");

            entity.Property(e => e.Department).HasMaxLength(60);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(12, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
