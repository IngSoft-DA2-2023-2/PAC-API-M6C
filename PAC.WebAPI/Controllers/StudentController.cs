using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;

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
        public ActionResult<List<Student>> GetAllStudents()
        {
            List<Student> result = _studentLogic.GetStudents().ToList();
            return result;
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student result = _studentLogic.GetStudentById(id);
            return result;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _studentLogic.InsertStudents(student);
            return Ok();
        }
    }
}
