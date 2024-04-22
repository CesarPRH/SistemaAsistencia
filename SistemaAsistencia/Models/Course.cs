namespace SistemaAsistencia.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LasttimeModified { get; set; }


        public Course (
            Guid id,
            string name,
            DateTime createdAt,
            DateTime lasttimeModified
            )
        { 
            Id = id;

            Name = name;
            CreatedAt = createdAt;
            LasttimeModified = lasttimeModified;
        } 
    }
}
