using System.Collections.Generic;

namespace KNU.IS.ClassScheduling.Data.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsLector { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}
