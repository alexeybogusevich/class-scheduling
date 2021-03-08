using System;

namespace KNU.IS.ClassScheduling.Data.Models
{
    public class TimePeriod
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string Period { get; set; }
    }
}
