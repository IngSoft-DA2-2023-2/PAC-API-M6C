using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _studentLogic.GetStudents();
        }

        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            Student? user = _studentLogic.GetStudentById(id);
            return user;
        }

        [HttpPost]
        public void InsertStudents(Student? student)
        {
            _studentLogic.InsertStudents(student);
        }
    }
}
