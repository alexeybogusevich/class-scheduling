using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BaseScheduleDomainProvider : IScheduleDomainProvider
    {
        private readonly ApplicationContext context;
        private readonly Random random = new Random();

        public BaseScheduleDomainProvider(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task GetAsync()
        {
            return await context.Courses
                .Include(c => c.CourseGroups)
                    .ThenInclude(cg => cg.Group)
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Instructor)
                .Include
                .Join(context.Groups,
                g => g.Id,
                c => c.)
        }

        public async Task<List<Course>> GetCourseDomainAsync()
        {
            return await context.Courses
                .Include(g => g.CourseGroups)
                    .ThenInclude(cg => cg.Group)
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Instructor)
                .OrderBy(_ => random.Next())
                .ToListAsync();
        }

        public async Task<List<Group>> GetGroupDomainAsync()
        {
            return await context.Groups
                .Include(g => g.CourceGroups)
                    .ThenInclude(cg => cg.Course)
                .OrderBy(_ => random.Next())
                .ToListAsync();
        }

        public async Task<List<Instructor>> GetInstructorDomainAsync()
        {
            return await context.Instructors
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Course)
                .OrderBy(_ => random.Next())
                .ToListAsync();
        }

        public async Task<List<Room>> GetRoomDomainAsync()
        {
            return await context.Rooms.OrderBy(_ => random.Next()).ToListAsync();
        }

        public async Task<List<TimePeriod>> GetTimePeriodDomainAsync()
        {
            return await context.TimePeriods.OrderBy(_ => random.Next()).ToListAsync();
        }
    }
}
