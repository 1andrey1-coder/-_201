using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Билет_20.DB;

public partial class User10Context : DbContext
{
    public User10Context()
    {
    }

    public User10Context(DbContextOptions<User10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;database=user10;user=user10;password=90513;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserFather).HasMaxLength(100);
            entity.Property(e => e.UserLogin).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserPassword).HasMaxLength(100);
            entity.Property(e => e.UserPhoto).HasColumnType("image");
            entity.Property(e => e.UserPosition).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
