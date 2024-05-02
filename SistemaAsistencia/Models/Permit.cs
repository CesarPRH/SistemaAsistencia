namespace SistemaAsistencia.Models
{
    public class Permit
    {
        public Guid IdPermit { get; set; }
        public Guid IdStudent { get; set; }
        public Guid IdProfessorInCourse { get; set; }
        public string Motive {  get; set; }
        public DateTime AbsenceDate { get; set; }
        public byte[] Proof { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastTimeModified { get; set; }

        public Permit
            (Guid idPermit, 
            Guid idStudent, 
            Guid idProfessorInCourse, 
            string motive, 
            DateTime absenceDate, 
            byte[] proof, 
            DateTime createdAt, 
            DateTime lastTimeModified)
        {
            IdPermit = idPermit;
            IdStudent = idStudent;
            IdProfessorInCourse = idProfessorInCourse;
            Motive = motive;
            AbsenceDate = absenceDate;
            Proof = proof;
            CreatedAt = createdAt;
            LastTimeModified = lastTimeModified;
        }
    }
}
