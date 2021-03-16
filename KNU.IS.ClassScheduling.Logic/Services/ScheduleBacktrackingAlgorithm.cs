using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class ScheduleBacktrackingAlgorithm : IBacktrackingAlgorithm<ScheduledClass>
    {
        private readonly Random random = new Random();
        private readonly IDomainProvider domainProvider;
        private readonly IScheduleManager scheduleManager;

        public ScheduleBacktrackingAlgorithm(
            IDomainProvider domainProvider, IScheduleManager scheduleManager)
        {
            this.domainProvider = domainProvider;
            this.scheduleManager = scheduleManager;
        }

        public async Task GenerateBasicSolutionAsync()
        {
            await domainProvider.InitializeAsync();
        }

        public bool BacktrackingSearch(List<ScheduledClass> scheduledClasses, int depth = 1)
        {
            Console.WriteLine(depth);

            var timePeriod = domainProvider.GetPeriod();

            if (timePeriod == null)
            {
                return true;
            }

            foreach (var course in domainProvider.GetCourses())
            {
                foreach (var hasParactice in domainProvider.GetHasPractice(course))
                {
                    foreach (var instructor in domainProvider.GetInstructors(timePeriod, course))
                    {
                        foreach (var room in domainProvider.GetRooms(timePeriod))
                        {
                            foreach (var groupList in domainProvider.GetGroups(timePeriod, course))
                            {
                                var scheduledClass = new ScheduledClass
                                {
                                    Id = random.Next(),
                                    Course = course,
                                    Groups = groupList,
                                    Instructor = instructor,
                                    TimePeriod = timePeriod,
                                    Room = room,
                                    IsLecture = hasParactice
                                };

                                scheduledClasses.Add(scheduledClass);
                                domainProvider.SetSelection(scheduledClass);

                                if (scheduleManager.CountConflicts(scheduledClasses) == 0)
                                {
                                    if (BacktrackingSearch(scheduledClasses, depth + 1))
                                    {
                                        return true;
                                    }
                                }

                                domainProvider.RemoveSelection(scheduledClass);
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
