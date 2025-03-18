using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.Data
{
    public class ELearningDbContext :DbContext
    {
        public ELearningDbContext(DbContextOptions<ELearningDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Student relationship
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithMany(u => u.Students)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User - Instructor relationship
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.User)
                .WithMany(u => u.Instructors)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Instructor - Course relationship
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);

            // Student - Enrollment relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Course - Enrollment relationship
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Course - Assessment relationship
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assessments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Assessment - Submission relationship
            modelBuilder.Entity<Assessment>()
                .HasMany(a => a.Submissions)
                .WithOne(s => s.Assessment)
                .HasForeignKey(s => s.AssessmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Student - Submission relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Submissions)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        internal Enrollment FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

