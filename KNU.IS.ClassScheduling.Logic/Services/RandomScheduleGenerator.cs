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
    public class RandomScheduleGenerator : IScheduleGenerator
    {
        public ApplicationContext context;

        public RandomScheduleGenerator(ApplicationContext context)
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

                    if (course.HasPractice)
                    {
                        scheludedClass.IsLecture = random.Next(100) < 30;
                    }
                    else
                    {
                        scheludedClass.IsLecture = true;
                    }

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
    }
}
