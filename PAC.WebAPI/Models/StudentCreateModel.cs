using PAC.Domain;

namespace PAC.WebAPI.Models;

public class StudentCreateModel
{
    public string Name { get; set; }

    public Student ToEntity()
    {
        return new Student()
        {
            Name = Name,
        };
    }
}