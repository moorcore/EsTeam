using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EsTeam
{
    public partial class EsTeamAppDBContext : DbContext
    {
        public EsTeamAppDBContext()
        {
        }

        public EsTeamAppDBContext(DbContextOptions<EsTeamAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Selection> Selections { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EsTeamAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).IsRequired();
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("Marks", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssessmentDate).HasColumnType("date");

                entity.Property(e => e.Mark1).HasColumnName("Mark");

                entity.Property(e => e.MarkDescription).IsRequired();

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marks_Parameters");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("Parameters", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ParameterName).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<Selection>(entity =>
            {
                entity.ToTable("Selections", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SelectionName).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Selections)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_Departments");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.Selections)
                    .HasForeignKey(d => d.ParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selections_Parameters");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "EsTeam");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Departments");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Statuses");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
