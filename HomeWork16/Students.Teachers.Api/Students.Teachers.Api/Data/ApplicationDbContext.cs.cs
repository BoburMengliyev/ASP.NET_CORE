using Microsoft.EntityFrameworkCore;
using Students.Teachers.Api.Models;

namespace Students.Teachers.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.StudentAdditionalDetail> StudentAdditionalDetails { get; set; }
        public DbSet<Models.Teacher> Teachers { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Models.StudentTeacher> StudentTeachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Student>()
                .HasMany(s => s.StudentTeachers)
                .WithOne(st => st.Student)
                .HasForeignKey(st => st.StudentId);
            
            modelBuilder.Entity<Models.Teacher>()
                .HasMany(t => t.StudentTeachers)
                .WithOne(st => st.Teacher)
                .HasForeignKey(st => st.TeacherId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Passport)
                .WithOne(p => p.Student)
                .HasForeignKey<Passport>(p => p.StudentId);

            modelBuilder.Entity<Models.StudentTeacher>()
                .HasKey(st => new { st.StudentId, st.TeacherId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
