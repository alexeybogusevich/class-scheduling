using KNU.IS.ClassScheduling.Data.Models;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class ScheduleBacktrackingAlgorithm
    {
        private readonly IScheduleDomainProvider domainProvider;
        private readonly IScheduleManager scheduleManager;

        public ScheduleBacktrackingAlgorithm(
            IScheduleDomainProvider domainProvider, IScheduleManager scheduleManager)
        {
            this.domainProvider = domainProvider;
            this.scheduleManager = scheduleManager;
        }

        private int TotalClassesToSchedule { get; set; }

        private List<Course> CourseDomain { get; }
        private List<Group> GroupDomain { get; }
        private List<Instructor> InstructorDomain { get; }
        private List<Room> RoomDomain { get; }

        private List<TimePeriod> TimePeriodDomain { get; }


        public async Task RunAsync()
        {
            TimePeriodDomain = await domainProvider.GetTimePeriodDomainAsync();

            CourseDomain = await domainProvider.GetCourseDomainAsync();
            GroupDomain = await domainProvider.GetGroupDomainAsync();
            InstructorDomain = await domainProvider.GetInstructorDomainAsync();
            RoomDomain = await domainProvider.GetRoomDomainAsync();

            TotalClassesToSchedule = GroupDomain
                .SelectMany(g => g.CourceGroups)
                .Sum(c => c.Course.Hours);

            var scheduledClasses = new List<ScheduledClass>();
        }

        private bool Backtrack(List<ScheduledClass> scheduledClasses)
        {
            if (scheduledClasses.Count() == TotalClassesToSchedule)
            {
                return true;
            }

            foreach (var course in CourseDomain)
            {
                foreach (var group in course.CourseGroups.Select(c => c.Group))
                {
                    foreach (var instructor in course.CourseInstructors.Select(c => c.Instructor))
                    {
                        foreach (var room in RoomDomain)
                        {
                            foreach (var timePeriod in TimePeriodDomain)
                            {
                                var scheduledClass = new ScheduledClass
                                {
                                    Id = scheduledClasses.Count(),
                                    Cource = course,
                                    Groups = groupList,
                                    Instructor = instructor,
                                    TimePeriod = timePeriod,
                                    Room = room,
                                    IsLecture = hasParactice
                                }

                                scheduledClasses.Add(scheduledClass);

                                if (scheduleManager.CountConflicts(scheduledClasses) == 0)
                                {
                                    if (Backtrack(scheduledClasses))
                                    {
                                        return true;
                                    }
                                }

                                scheduledClasses.Remove(scheduledClass);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
