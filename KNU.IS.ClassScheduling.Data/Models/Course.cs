using System.Collections.Generic;

namespace KNU.IS.ClassScheduling.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public bool HasPractice { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

        public virtual ICollection<CourseGroup> CourseGroups { get; set; } = new List<CourseGroup>();
    }
}
