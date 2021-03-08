namespace KNU.IS.ClassScheduling.Data.Models
{
    public class CourseInstructor
    {
        public int CourceId { get; set; }
        public virtual Course Course { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
