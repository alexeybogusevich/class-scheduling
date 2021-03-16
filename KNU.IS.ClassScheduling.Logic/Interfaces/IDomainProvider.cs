using KNU.IS.ClassScheduling.Data.Models;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IDomainProvider
    {
        Task InitializeAsync();
        TimePeriod GetPeriod();
        IEnumerable<Course> GetCourses();
        IEnumerable<Room> GetRooms(TimePeriod timePeriod);
        IEnumerable<Instructor> GetInstructors(TimePeriod timePeriod, Course course);
        IEnumerable<IEnumerable<Group>> GetGroups(TimePeriod timePeriod, Course course);
        IEnumerable<bool> GetHasPractice(Course course);
        void SetSelection(ScheduledClass schedulerClass);
        void RemoveSelection(ScheduledClass scheluderClass);
    }
}
