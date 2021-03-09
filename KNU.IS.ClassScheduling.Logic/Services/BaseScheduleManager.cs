using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BaseScheduleManager : IScheduleManager
    {
        public ApplicationContext context;

        public BaseScheduleManager(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ScheduledClass>> GenerateAsync()
        {
            var random = new Random();
            var scheduledClasses = new List<ScheduledClass>();

            var locId = 1;
            var courses = await context.Courses
                .Include(c => c.CourseInstructors)
                    .ThenInclude(ci => ci.Instructor)
                .Include(c => c.CourceGroups)
                    .ThenInclude(cg => cg.Group)
                .ToListAsync();

            var timePeriods = await context.TimePeriods.ToArrayAsync();

            foreach (var course in courses)
            {
                foreach (var _ in Enumerable.Range(0, course.Hours))
                {
                    var scheludedClass = new ScheduledClass
                    {
                        Id = locId++,
                        Course = course
                    };

                    scheludedClass.IsLecture = course.HasPractice ? random.Next(100) < 30 : true;

                    scheludedClass.Groups = course.CourceGroups
                        .Select(cg => cg.Group)
                        .OrderBy(_ => random.Next())
                        .Take(random.Next(1, course.CourceGroups.Count))
                        .ToList();

                    scheludedClass.Instructor = course.CourseInstructors
                        .Select(ci => ci.Instructor)
                        .Where(i => i.IsLector || !scheludedClass.IsLecture)
                        .OrderBy(_ => random.Next())
                        .FirstOrDefault();

                    scheludedClass.Instructor ??= await context.Instructors
                        .OrderBy(_ => random.Next())
                        .FirstOrDefaultAsync();

                    var studentsAmount = scheludedClass.Groups.Sum(g => g.StudentsAmount);
                    scheludedClass.Room = await context.Rooms
                        .Where(r => r.Capacity >= studentsAmount)
                        .OrderBy(_ => random.Next())
                        .FirstOrDefaultAsync();

                    scheludedClass.Room ??= await context.Rooms.FirstOrDefaultAsync();

                    scheludedClass.TimePeriod = timePeriods[random.Next(timePeriods.Length)];

                    scheduledClasses.Add(scheludedClass);
                }
            }

            return scheduledClasses;
        }

        public int GountConflicts(IEnumerable<ScheduledClass> scheduledClasses)
        {
            int conflicts = 0;

            foreach (var scheduledClass in scheduledClasses)
            {
                if (!scheduledClass.Instructor.IsLector && scheduledClass.IsLecture)
                {
                    conflicts += 1;
                }

                if (scheduledClass.Room.Capacity < scheduledClass.Groups.Sum(g => g.StudentsAmount))
                {
                    conflicts += 1;
                }

                conflicts += scheduledClasses.Where(c =>
                    (c.Room.Id == scheduledClass.Room.Id ||
                    c.Groups.Intersect(scheduledClass.Groups).Count() > 0 ||
                    c.Instructor.Id == scheduledClass.Instructor.Id) &&
                    c.TimePeriod.Id == scheduledClass.TimePeriod.Id &&
                    c.Id != scheduledClass.Id).Count();

                foreach (var g in scheduledClass.Groups)
                {
                    conflicts += scheduledClasses
                        .Where(
                            c => c.Groups.Contains(g) &&
                            c.Course.Id == scheduledClass.Course.Id)
                        .Count() > scheduledClass.Course.Hours
                        ?
                        1 : 0;
                }
            }

            return conflicts;
        }
    }
}
