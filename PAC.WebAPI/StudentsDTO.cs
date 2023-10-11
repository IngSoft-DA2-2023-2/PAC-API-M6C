using PAC.Domain;

namespace PAC.WebAPI
{
    public class StudentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentsDTO(Student student)
        {
            Id = student.Id;
            Name = student.Name;
        }
    }
}
