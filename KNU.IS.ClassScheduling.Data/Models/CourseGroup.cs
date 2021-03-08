namespace KNU.IS.ClassScheduling.Data.Models
{
    public class CourseGroup
    {
        public int CourceId { get; set; }
        public virtual Course Course { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
