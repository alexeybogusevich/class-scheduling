using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasKey(ci => new { ci.CourceId, ci.InstructorId });

            builder.HasOne(c => c.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(c => c.CourceId);

            builder.HasOne(c => c.Instructor)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(c => c.InstructorId);

            builder.HasData(
                new CourseInstructor() { CourceId = 1, InstructorId = 1 },
                new CourseInstructor() { CourceId = 1, InstructorId = 2 },
                new CourseInstructor() { CourceId = 1, InstructorId = 6 },
                new CourseInstructor() { CourceId = 1, InstructorId = 7 },
                new CourseInstructor() { CourceId = 2, InstructorId = 2 },
                new CourseInstructor() { CourceId = 2, InstructorId = 8 },
                new CourseInstructor() { CourceId = 3, InstructorId = 4 },
                new CourseInstructor() { CourceId = 3, InstructorId = 5 },
                new CourseInstructor() { CourceId = 4, InstructorId = 5 },
                new CourseInstructor() { CourceId = 4, InstructorId = 3 },
                new CourseInstructor() { CourceId = 4, InstructorId = 2 },
                new CourseInstructor() { CourceId = 5, InstructorId = 12 },
                new CourseInstructor() { CourceId = 6, InstructorId = 8 },
                new CourseInstructor() { CourceId = 6, InstructorId = 9 },
                new CourseInstructor() { CourceId = 6, InstructorId = 10 },
                new CourseInstructor() { CourceId = 7, InstructorId = 5 },
                new CourseInstructor() { CourceId = 7, InstructorId = 9 },
                new CourseInstructor() { CourceId = 8, InstructorId = 6 },
                new CourseInstructor() { CourceId = 8, InstructorId = 7 },
                new CourseInstructor() { CourceId = 8, InstructorId = 9 },
                new CourseInstructor() { CourceId = 9, InstructorId = 11 },
                new CourseInstructor() { CourceId = 9, InstructorId = 2 },
                new CourseInstructor() { CourceId = 9, InstructorId = 10 },
                new CourseInstructor() { CourceId = 10, InstructorId = 11 },
                new CourseInstructor() { CourceId = 10, InstructorId = 8 }
            );
        }
    }
}
