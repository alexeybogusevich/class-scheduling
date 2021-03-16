using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.CSP;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class BaseDomainProvider : IDomainProvider
    {
        protected Random random = new Random();
        protected readonly ApplicationContext context;

        public BaseDomainProvider(ApplicationContext context)
        {
            this.context = context;
        }

        protected IDictionary<int, SelectionScope> timePeriodSelections;
        protected IDictionary<int, IDictionary<int, int>> courseHours;

        protected List<Course> courses;
        protected List<Instructor> instructors;
        protected List<Room> rooms;
        protected List<Group> groups;

        protected TimePeriod[] timePeriods;

        public virtual async Task InitializeAsync()
        {
            instructors = await context.Instructors.ToListAsync();
            courses = await context.Courses.Include(c => c.CourseGroups).ToListAsync();
            rooms = await context.Rooms.ToListAsync();
            groups = await context.Groups.ToListAsync();

            timePeriods = await context.TimePeriods.ToArrayAsync();
            timePeriodSelections = new Dictionary<int, SelectionScope>();

            foreach (var timePeriod in timePeriods)
            {
                timePeriodSelections.Add(timePeriod.Id, new SelectionScope());
            }

            courseHours = new Dictionary<int, IDictionary<int, int>>();
            foreach (var cource in courses)
            {
                var dict = new Dictionary<int, int>();
                foreach (var group in cource.CourseGroups)
                {
                    dict.Add(group.GroupId, 0);
                }
                courseHours.Add(cource.Id, dict);
            }
        }

        public virtual IEnumerable<Course> GetCourses()
        {
            return courses.Where(cource => courseHours[cource.Id].Any(ch => ch.Value < cource.Hours));
        }

        public virtual IEnumerable<IEnumerable<Group>> GetGroups(TimePeriod timePeriod, Course course)
        {
            var availableGroups = groups
                .Where(group => courseHours[course.Id].ContainsKey(group.Id) && !timePeriodSelections[timePeriod.Id].GroupsTaken.Contains(group.Id))
                .ToList();

            return availableGroups
                .Zip(availableGroups)
                .Select(pair => new List<Group> 
                {
                    pair.First,
                    pair.Second
                })
                .Union(availableGroups
                    .Select(group => new List<Group> { group }));
        }

        public virtual IEnumerable<Instructor> GetInstructors(TimePeriod timePeriod, Course course)
        {
            return instructors
                .Where(instructor => !timePeriodSelections[timePeriod.Id].InstructorsTaken.Contains(instructor.Id));
        }

        public virtual TimePeriod GetPeriod()
        {
            if (AllHoursUsed())
            {
                return null;
            }

            return timePeriods[random.Next(timePeriods.Length)];
        }

        public virtual IEnumerable<Room> GetRooms(TimePeriod timePeriod)
        {
            return rooms
               .Where(room => !timePeriodSelections[timePeriod.Id].RoomsTaken.Contains(room.Id));
        }
        protected virtual bool AllHoursUsed()
        {
            return !courses.Any(c => courseHours[c.Id].Any(ch => ch.Value < c.Hours));
        }

        public virtual void SetSelection(ScheduledClass schedulerClass)
        {
            timePeriodSelections[schedulerClass.TimePeriod.Id].RoomsTaken.Add(schedulerClass.Room.Id);
            timePeriodSelections[schedulerClass.TimePeriod.Id].InstructorsTaken.Add(schedulerClass.Instructor.Id);

            foreach (var group in schedulerClass.Groups)
            {
                timePeriodSelections[schedulerClass.TimePeriod.Id].GroupsTaken.Add(group.Id); 
                courseHours[schedulerClass.Course.Id][group.Id]++;
            }
        }

        public virtual void RemoveSelection(ScheduledClass schedulerClass)
        {
            timePeriodSelections[schedulerClass.TimePeriod.Id].RoomsTaken.Remove(schedulerClass.Room.Id);
            timePeriodSelections[schedulerClass.TimePeriod.Id].InstructorsTaken.Remove(schedulerClass.Instructor.Id);

            foreach (var group in schedulerClass.Groups)
            {
                timePeriodSelections[schedulerClass.TimePeriod.Id].GroupsTaken.Remove(group.Id);
                courseHours[schedulerClass.Course.Id][group.Id]--;
            }
        }

        public virtual IEnumerable<bool> GetHasPractice(Course course)
        {
            return (new List<bool> { true, false }).Where(b => b || course.HasPractice); 
        }
    }
}
