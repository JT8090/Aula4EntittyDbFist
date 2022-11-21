//using System;
//using System.Collections.Generic;
//using Capitulo4.EntityFramework.Models;
//using Microsoft.EntityFrameworkCore;

using Capitulo4.EntityFramework.Models;

namespace Capitulo4.EntityFramework.Data;

public partial class NorthWindContext : DbContext
{
    public NorthWindContext()
    {
    }

    public NorthWindContext(DbContextOptions<NorthWindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=NorthWind; User Id=sa; Password=sa01; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasConstraintName("FK_Employees_Employees");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
