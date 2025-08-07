namespace Students.Teachers.Api.Models
{
    public class Passport
    {
        public Guid Id { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
