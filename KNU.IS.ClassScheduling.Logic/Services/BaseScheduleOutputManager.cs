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
                sb.AppendLine(string.Concat(Enumerable.Repeat("-", 100)));
                sb.AppendLine();
                sb.AppendLine($"\tГРУПА: {group.Name}");
                sb.AppendLine();

                var days = items.Where(c => c.Groups.Any(g => g.Id == group.Id))
                    .OrderBy(c => c.TimePeriod.Id)
                    .GroupBy(c => c.TimePeriod.DayOfWeek)
                    .ToList();

                var cultureInfo = CultureInfo.CurrentCulture;

                foreach (var day in days)
                {
                    sb.AppendLine();
                    sb.AppendLine($"\t{GetLocalDayOfWeek(day.Key, cultureInfo).ToUpper()}");
                    foreach (var gClass in day)
                    {
                        sb.AppendLine($"\t{gClass.TimePeriod.Period}. {gClass.Course.Name} ({(gClass.IsLecture ? "Л" : "П")}) ауд. {gClass.Room.Name} ({gClass.Instructor.Name})");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private string GetLocalDayOfWeek(DayOfWeek dayOfWeek, CultureInfo cultureInfo)
        {
            return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
        }
    }
}
