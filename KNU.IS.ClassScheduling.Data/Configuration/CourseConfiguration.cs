using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course() { Id = 1, Name = "Математичний аналіз", HasPractice = true, Hours = 4 },
                new Course() { Id = 2, Name = "Алгебра та геометрія", HasPractice = true, Hours = 3 },
                new Course() { Id = 3, Name = "Дискретна математика", HasPractice = true, Hours = 2 },
                new Course() { Id = 4, Name = "Дослідження операцій", HasPractice = true, Hours = 3 },
                new Course() { Id = 5, Name = "Українська література", HasPractice = false, Hours = 1 },
                new Course() { Id = 6, Name = "ООП", HasPractice = true, Hours = 4 },
                new Course() { Id = 7, Name = "Криптографія", HasPractice = true, Hours = 4 },
                new Course() { Id = 8, Name = "Хмарні обчислення", HasPractice = false, Hours = 2 },
                new Course() { Id = 9, Name = "Інформаційні системи", HasPractice = true, Hours = 3 },
                new Course() { Id = 10, Name = "SQL-подібні мови", HasPractice = false, Hours = 2 }
            );
        }
    }
}
