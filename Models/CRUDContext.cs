using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UniCourses.Models
{
    public partial class CRUDContext : DbContext
    {
        public CRUDContext()
        {
        }

        public CRUDContext(DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<University> University { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Courses__A9FDEC12AEA41996");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CDuration)
                    .HasColumnName("C_DURATION")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CName)
                    .HasColumnName("C_NAME")
                    .HasMaxLength(1800)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.UniversityId).HasColumnName("UNIVERSITY_ID");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK__Courses__UNIVERS__3E52440B");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
