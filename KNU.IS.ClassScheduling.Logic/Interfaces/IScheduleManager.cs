using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IScheduleManager
    {
        int CountConflicts(IEnumerable<ScheduledClass> scheduledClasses);
        Task<IEnumerable<ScheduledClass>> GenerateAsync();
    }
}
