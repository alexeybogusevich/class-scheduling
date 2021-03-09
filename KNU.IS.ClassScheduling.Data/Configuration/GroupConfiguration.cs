using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasData(
                new Group() { Id = 1, Name = "K12", StudentsAmount = 20 },
                new Group() { Id = 2, Name = "K15", StudentsAmount = 25 },
                new Group() { Id = 3, Name = "K16", StudentsAmount = 28 },
                new Group() { Id = 4, Name = "K22", StudentsAmount = 18 },
                new Group() { Id = 5, Name = "K25", StudentsAmount = 23 },
                new Group() { Id = 6, Name = "K26", StudentsAmount = 21 },
                new Group() { Id = 7, Name = "ТТП3", StudentsAmount = 45 },
                new Group() { Id = 8, Name = "МІ3", StudentsAmount = 24 },
                new Group() { Id = 9, Name = "ТК3", StudentsAmount = 23 },
                new Group() { Id = 10, Name = "ТТП4", StudentsAmount = 36 },
                new Group() { Id = 11, Name = "МІ4", StudentsAmount = 17 }
            );
        }
    }
}
