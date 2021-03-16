using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class RandomDomainProvider : LCVDomainProvider
    {
        public RandomDomainProvider(ApplicationContext context) : base(context) { }

        public override IEnumerable<Instructor> GetInstructors(TimePeriod timePeriod, Course course)
        {
            return base.GetInstructors(timePeriod, course).OrderBy(_ => random.Next());
        }

        public override IEnumerable<Room> GetRooms(TimePeriod timePeriod)
        {
            return base.GetRooms(timePeriod).OrderBy(_ => random.Next());   
        }

        public override IEnumerable<Course> GetCourses()
        {
            return base.GetCourses().OrderBy(_ => random.Next());
        }

        public override IEnumerable<IEnumerable<Group>> GetGroups(TimePeriod timePeriod, Course course)
        {
            return base.GetGroups(timePeriod, course).OrderBy(_ => random.Next());
        }

        public override IEnumerable<bool> GetHasPractice(Course course)
        {
            return base.GetHasPractice(course).OrderBy(_ => random.Next());
        }
    }
}
