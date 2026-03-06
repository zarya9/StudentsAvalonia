using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentsAvalonia.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB ; Database=Test931 ; Trusted_Connection=True; Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("Group");

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
            entity.Property(e => e.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(e => e.Number).HasMaxLength(50);

            entity.HasOne(d => d.IdSpecialityNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdSpeciality)
                .HasConstraintName("FK_Group_Speciality");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogins);

            entity.Property(e => e.IdLogins).HasColumnName("ID_Logins");
            entity.Property(e => e.LoginName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality);

            entity.ToTable("Speciality");

            entity.Property(e => e.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(e => e.NameSpeciality)
                .HasMaxLength(50)
                .HasColumnName("Name_Speciality");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FName");
            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");
            entity.Property(e => e.IdLogPass).HasColumnName("ID_Log_Pass");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronumic).HasMaxLength(50);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_Users_Group");

            entity.HasOne(d => d.IdLogPassNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdLogPass)
                .HasConstraintName("FK_Users_Logins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
