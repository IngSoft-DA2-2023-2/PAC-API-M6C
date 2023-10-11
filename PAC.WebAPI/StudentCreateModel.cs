using PAC.Domain;

namespace PAC.WebAPI
{
    public class StudentCreateModel
    {
        public string Name { get; set; }

        public Student ToEntity()
        {
            return new Student()
            {
                Name = this.Name,
            };
        }
    }
}
