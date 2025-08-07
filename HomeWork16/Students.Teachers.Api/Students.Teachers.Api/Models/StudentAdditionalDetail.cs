using System.Text.Json.Serialization;

namespace Students.Teachers.Api.Models
{
    public class StudentAdditionalDetail
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
        public Guid StudentId { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
