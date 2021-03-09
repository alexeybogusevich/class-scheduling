using KNU.IS.ClassScheduling.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IScheduleDomainProvider
    {
        Task<List<Course>> GetCourseDomainAsync();
        Task<List<Group>> GetGroupDomainAsync();
        Task<List<Instructor>> GetInstructorDomainAsync();
        Task<List<Room>> GetRoomDomainAsync();
        Task<List<TimePeriod>> GetTimePeriodDomainAsync();
    }
}
