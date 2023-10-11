namespace PAC.Domain;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
       Student otherAsStudent = obj as Student;

       return Id == otherAsStudent.Id && Name == otherAsStudent.Name;
    }


}

