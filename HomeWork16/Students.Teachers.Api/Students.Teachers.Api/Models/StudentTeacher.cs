namespace Students.Teachers.Api.Models
{
    public class StudentTeacher
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
