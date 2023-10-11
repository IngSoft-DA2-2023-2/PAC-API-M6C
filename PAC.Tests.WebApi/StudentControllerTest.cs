namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private StudentController _studentController;
        private Mock<IStudentLogic> _studentLogicMock;

        [TestInitialize]
        public void InitTest()
        {
            _studentLogicMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            _studentController = new StudentController(_studentLogicMock.Object);
        }

        [TestMethod]
        public void TestGetAllStudentsOk()
        {
            var students = new List<Student>
            {
                new Student { Id=1},
                new Student { Id=2}

            };

            _studentLogicMock.Setup(logic => logic.GetStudents()).Returns(students);

            var result = _studentController.Students() as ObjectResult;

           
            Assert.IsNotNull(result); 
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetStudentOk()
        {
           
            Student studentToReturn = new Student()
            {
                Id = 1
            };

           
            _studentLogicMock.Setup(u => u.GetStudentById(It.IsAny<int>())).Returns(studentToReturn);

            
            var result = _studentController.GetStudent(1) as IActionResult; 

           
            Assert.IsNotNull(result); 

            if (result is OkObjectResult okResult)
            {
               
                var studentResult = okResult.Value as Student;

                Assert.IsNotNull(studentResult);
                Assert.AreEqual(studentToReturn.Id, studentResult.Id);
            }
            
            _studentLogicMock.Verify(u => u.GetStudentById(1), Times.Once);
        }


        [TestMethod]
        public void TestCreateStudentOk()
        {
            
            Student studentToCreate = new Student
            {
                Id = 1,
                Name = "John Doe"
            };


            _studentLogicMock.Setup(u => u.InsertStudents(studentToCreate));

            
            var result = _studentController.Students(studentToCreate) as IActionResult;

         
            Assert.IsNotNull(result); 

            if (result is CreatedResult createdResult)
            {
               
                Assert.AreEqual(201, createdResult.StatusCode);

        
                var createdStudent = createdResult.Value as Student;

                Assert.IsNotNull(createdStudent); 
                Assert.AreEqual(studentToCreate.Id, createdStudent.Id);
                Assert.AreEqual(studentToCreate.Name, createdStudent.Name);
            }
            else
            {
              
            }

            _studentLogicMock.Verify(u => u.InsertStudents(studentToCreate), Times.Once); 
        }
    }
}
 