using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BaseScheduleOutputManager : IAlgorithmOutputManager<ScheduledClass>
    {
        public string GetOutput(IEnumerable<ScheduledClass> items)
        {
            var sb = new StringBuilder();

            var groups = items.SelectMany(c => c.Groups).Distinct();

            foreach (var group in groups)
            {
                sb.AppendLine();
                sb.AppendLine(group.Name);
                sb.AppendLine();

                var groupClasses = items.Where(c => c.Groups.Any(g => g.Id == group.Id))
                    .OrderBy(c => c.TimePeriod.Id)
                    .ToList();

                var cultureInfo = CultureInfo.CurrentCulture;

                foreach (var gclass in groupClasses)
                {
                    sb.AppendLine();
                    sb.AppendLine(GetLocalDayOfWeek(gclass.TimePeriod.DayOfWeek, cultureInfo).ToUpper());
                    sb.AppendLine($"{gclass.TimePeriod.Period}. {gclass.Course.Name} ({(gclass.IsLecture ? "Л" : "П")}) ауд. {gclass.Room.Name} ({gclass.Instructor.Name})");
                }
            }

            return sb.ToString();
        }

        private string GetLocalDayOfWeek(DayOfWeek dayOfWeek, CultureInfo cultureInfo)
        {
            return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
        }
    }
}
