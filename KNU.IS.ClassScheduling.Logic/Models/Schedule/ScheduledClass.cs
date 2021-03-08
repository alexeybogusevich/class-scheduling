using KNU.IS.ClassScheduling.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace KNU.IS.ClassScheduling.Logic.Models.Schedule
{
    public class ScheduledClass
    {
        public int Id { get; set; }

        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public TimePeriod TimePeriod { get; set; }
        public Room Room { get; set; }
        public bool IsLecture { get; set; }

        public override string ToString()
        {
            return 
                $"[{Course.Name}({(IsLecture ? "Л" : "П")}), " +
                $"{Room.Name}, " +
                $"{TimePeriod.DayOfWeek}:{TimePeriod.Period}, " +
                $"{Instructor.Name}, " +
                $"Групи:{string.Join(',', Groups.Select(g => g.Name))}";
        }
    }
}
