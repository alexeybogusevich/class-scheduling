using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
                new Instructor() { Id = 1, Name = "Іванов Петро", IsLector = true },
                new Instructor() { Id = 2, Name = "Іванов Cтепан", IsLector = false },
                new Instructor() { Id = 3, Name = "Петров Петро", IsLector = false },
                new Instructor() { Id = 4, Name = "Петров Віктор", IsLector = true },
                new Instructor() { Id = 5, Name = "Іванова Галина", IsLector = false },
                new Instructor() { Id = 6, Name = "Бойко Сергій", IsLector = false },
                new Instructor() { Id = 7, Name = "Підгорна Олександра", IsLector = true },
                new Instructor() { Id = 8, Name = "Колесо Іван", IsLector = true },
                new Instructor() { Id = 9, Name = "Видний Тарас", IsLector = true },
                new Instructor() { Id = 10, Name = "Тирса Микола", IsLector = true },
                new Instructor() { Id = 11, Name = "Жолудь Сергій", IsLector = false },
                new Instructor() { Id = 12, Name = "Холодниченко Олександр", IsLector = true }
            );
        }
    }
}
