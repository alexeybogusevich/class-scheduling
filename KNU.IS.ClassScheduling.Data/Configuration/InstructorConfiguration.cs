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
                new Instructor() { Id = 1, Name = "Рубльов Богдан", IsLector = true },
                new Instructor() { Id = 2, Name = "Анікушин Андрій", IsLector = false },
                new Instructor() { Id = 3, Name = "Іксанов Олександр", IsLector = false },
                new Instructor() { Id = 4, Name = "Петрушенко Анатолій", IsLector = true },
                new Instructor() { Id = 5, Name = "Шевченко Валерій", IsLector = false },
                new Instructor() { Id = 6, Name = "Молодцов Олександр", IsLector = false },
                new Instructor() { Id = 7, Name = "Дерев\'янченко Олександр", IsLector = true },
                new Instructor() { Id = 8, Name = "Рабанович В\'ячеслав", IsLector = true },
                new Instructor() { Id = 9, Name = "Федорус Олексій", IsLector = true },
                new Instructor() { Id = 10, Name = "Іванов Євгеній", IsLector = true },
                new Instructor() { Id = 11, Name = "Жолудь Сергій", IsLector = false },
                new Instructor() { Id = 12, Name = "Рябоконь Євгеній", IsLector = true }
            );
        }
    }
}
