using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class TimePeriodConfiguration : IEntityTypeConfiguration<TimePeriod>
    {
        public void Configure(EntityTypeBuilder<TimePeriod> builder)
        {
            builder.HasData(
                new TimePeriod() { Id = 1, DayOfWeek = System.DayOfWeek.Monday, Period = "I" },
                new TimePeriod() { Id = 2, DayOfWeek = System.DayOfWeek.Monday, Period = "II" },
                new TimePeriod() { Id = 3, DayOfWeek = System.DayOfWeek.Monday, Period = "III" },
                new TimePeriod() { Id = 4, DayOfWeek = System.DayOfWeek.Monday, Period = "IV" },

                new TimePeriod() { Id = 5, DayOfWeek = System.DayOfWeek.Tuesday, Period = "I" },
                new TimePeriod() { Id = 6, DayOfWeek = System.DayOfWeek.Tuesday, Period = "II" },
                new TimePeriod() { Id = 7, DayOfWeek = System.DayOfWeek.Tuesday, Period = "III" },
                new TimePeriod() { Id = 8, DayOfWeek = System.DayOfWeek.Tuesday, Period = "IV" },

                new TimePeriod() { Id = 9, DayOfWeek = System.DayOfWeek.Wednesday, Period = "I" },
                new TimePeriod() { Id = 10, DayOfWeek = System.DayOfWeek.Wednesday, Period = "II" },
                new TimePeriod() { Id = 11, DayOfWeek = System.DayOfWeek.Wednesday, Period = "III" },
                new TimePeriod() { Id = 12, DayOfWeek = System.DayOfWeek.Wednesday, Period = "IV" },

                new TimePeriod() { Id = 13, DayOfWeek = System.DayOfWeek.Thursday, Period = "I" },
                new TimePeriod() { Id = 14, DayOfWeek = System.DayOfWeek.Thursday, Period = "II" },
                new TimePeriod() { Id = 15, DayOfWeek = System.DayOfWeek.Thursday, Period = "III" },
                new TimePeriod() { Id = 16, DayOfWeek = System.DayOfWeek.Thursday, Period = "IV" },

                new TimePeriod() { Id = 17, DayOfWeek = System.DayOfWeek.Friday, Period = "I" },
                new TimePeriod() { Id = 18, DayOfWeek = System.DayOfWeek.Friday, Period = "II" },
                new TimePeriod() { Id = 19, DayOfWeek = System.DayOfWeek.Friday, Period = "III" },
                new TimePeriod() { Id = 20, DayOfWeek = System.DayOfWeek.Friday, Period = "IV" }
            );
        }
    }
}
