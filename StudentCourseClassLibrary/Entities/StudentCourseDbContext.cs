using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseClassLibrary.Entities;

public partial class StudentCourseDbContext : DbContext
{
    public StudentCourseDbContext()
    {
    }

    public StudentCourseDbContext(DbContextOptions<StudentCourseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblStudentCourse> TblStudentCourses { get; set; }

    public virtual DbSet<TblStudentCourseTemp> TblStudentCourseTemps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=nishikawa\\SQLEXPRESS;Initial Catalog=StudentCourseDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.ToTable("TblCourse");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Course).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("TblStudent");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblStudentCourse>(entity =>
        {
            entity.HasKey(e => e.StudentCourseId);

            entity.ToTable("TblStudentCourse");

            entity.Property(e => e.StudentCourseId).HasColumnName("StudentCourseID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.TblStudentCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStudentCourse_TblCourse");

            entity.HasOne(d => d.Student).WithMany(p => p.TblStudentCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStudentCourse_TblStudent");
        });

        modelBuilder.Entity<TblStudentCourseTemp>(entity =>
        {
            entity.HasKey(e => e.StudentCourseTempId);

            entity.ToTable("TblStudentCourseTemp");

            entity.Property(e => e.StudentCourseTempId)
                .ValueGeneratedNever()
                .HasColumnName("StudentCourseTempID");
            entity.Property(e => e.CourseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CourseID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.TblStudentCourseTemps)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStudentCourseTemp_TblCourse");

            entity.HasOne(d => d.Student).WithMany(p => p.TblStudentCourseTemps)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblStudentCourseTemp_TblStudent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
