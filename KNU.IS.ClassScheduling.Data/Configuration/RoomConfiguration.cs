using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room() { Id = 1, Name = "2", Capacity = 16 },
                new Room() { Id = 2, Name = "3", Capacity = 16 },
                new Room() { Id = 3, Name = "5", Capacity = 16 },
                new Room() { Id = 4, Name = "204", Capacity = 30 },
                new Room() { Id = 5, Name = "303", Capacity = 20 },
                new Room() { Id = 6, Name = "304", Capacity = 20 },
                new Room() { Id = 7, Name = "211", Capacity = 50 },
                new Room() { Id = 8, Name = "39", Capacity = 120 },
                new Room() { Id = 9, Name = "40", Capacity = 90 },
                new Room() { Id = 10, Name = "43", Capacity = 120 }
            );
        }
    }
}
