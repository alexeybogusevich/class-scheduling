using System.Collections.Generic;

namespace KNU.IS.ClassScheduling.Data.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentsAmount { get; set; }
        public virtual ICollection<CourseGroup> CourceGroups { get; private set; } = new List<CourseGroup>();
    }
}
