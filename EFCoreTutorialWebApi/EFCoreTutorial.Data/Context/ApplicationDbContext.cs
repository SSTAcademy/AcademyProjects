using EFCoreTutorial.Common;
using EFCoreTutorial.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorial.Data.Context
{
    //entity framework aracılığı ile veritabanına giden ve ordaki işlemleri geröekleştiren context'tir.
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAdress> StudentAdresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //make the configure
                optionsBuilder.UseSqlServer(StringConstants.DbConnectionString);
            }
            //var list = Courses.Where(i=>i.Name =="English").Select(i=>i.Name).ToList();
            // await this.Courses.ToListAsync();

        }

        //veritabanında hangi isim ve özelliklerle kullanabileceğimizi gösteren yer
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");
                entity.Property(i => i.Id).HasColumnName("Id").HasColumnType("int").UseIdentityColumn().IsRequired();
                entity.Property(i => i.FirstName)
                .HasColumnName("name")
                .HasColumnType("nvarchar").HasMaxLength(100);

                entity.HasOne(i => i.Adress)
                .WithOne(i => i.Student)
                .HasForeignKey<StudentAdress>(i => i.StudentId)
                .HasConstraintName("student_adressid_fk");

                entity.HasMany(i => i.Books)
                .WithOne(i => i.Student)
                .HasForeignKey(i => i.StudentId)
                .HasConstraintName("student_book_id_fk");
            });

            modelBuilder.Entity<StudentAdress>(entity =>
            {
                entity.ToTable("student_adresses");
                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(i => i.City).HasColumnName("city").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.District).HasColumnName("district").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Country).HasColumnName("country").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.FullAdress).HasColumnName("full_adress").HasColumnType("nvarchar").HasMaxLength(100);

                entity.HasOne(i => i.Student)
                .WithOne(i => i.Adress)
                .HasForeignKey<Student>(i => i.AdressId)
                .HasConstraintName("student_adress_student_id_fk");

              
            });


            //modelBuilder.Entity<Student>().Property(i => i.Id)
            //    .HasColumnName("id")
            //    .HasColumnType("int").IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
