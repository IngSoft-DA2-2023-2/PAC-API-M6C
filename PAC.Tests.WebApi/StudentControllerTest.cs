using Microsoft.AspNetCore.Mvc;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;

using PAC.WebAPI;
using Microsoft.AspNetCore.Http;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic> _mockStudentLogic;
    private StudentController _studentController;

    [TestInitialize]
    public void InitTest()
    {
        _mockStudentLogic = new Mock<IStudentLogic>();
        _studentController = new StudentController(_mockStudentLogic.Object);
    }

    [TestMethod]
    public void GetAllStudentsCorrectTest()
    {
        
        
        var mockStudents = new List<Student>
        {
            new Student { Id = 1, Name = "John" },
            new Student { Id = 2, Name = "Jane" }
        };

        _mockStudentLogic.Setup(x => x.GetStudents()).Returns(mockStudents);

        
        var result = _studentController.GetAllStudents();
        _mockStudentLogic.VerifyAll();


        OkObjectResult okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);

        var students = okResult.Value as List<Student>;
        Assert.AreEqual(2, students.Count);
    }
    [TestMethod]
    public void GetStudentByIdCorrectTest()
    {
        
        var mockStudent = new Student { Id = 1, Name = "John" };
        _mockStudentLogic.Setup(x => x.GetStudentById(1)).Returns(mockStudent);

        
        var result = _studentController.GetStudentById(1);


        OkObjectResult okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        var student = okResult.Value as Student;
        Assert.AreEqual("John", student.Name);
    }
    [TestMethod]
    public void CreateStudentCorrectTest()
    {

        var newStudent = new Student { Id = 2, Name = "Jane" };
        _mockStudentLogic.Setup(x => x.InsertStudents(newStudent));

        var contextMock = new Mock<HttpContext>();
        var headers = new HeaderDictionary();
        headers["UserRole"] = "admin";
        contextMock.SetupGet(x => x.Request.Headers).Returns(headers);

        _studentController.ControllerContext = new ControllerContext();
        _studentController.ControllerContext.HttpContext = contextMock.Object;

        var result = _studentController.CreateStudent(newStudent);

        var createdResult = result as CreatedAtActionResult;
        Assert.IsNotNull(createdResult);
        Assert.AreEqual(201, createdResult.StatusCode);
        var student = createdResult.Value as Student;
        Assert.AreEqual("Jane", student.Name);
    }

}
