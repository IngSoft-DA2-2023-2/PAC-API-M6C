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

        [HttpGet("student-list")]
        public IActionResult GetStudents()
        {
            IEnumerable<Student> result = _studentLogic.GetStudents();
            return Ok(result);
        }

        [HttpGet("student-by-id")]
        public IActionResult GetStudentById([FromQuery] int id)
        {
            Student result = _studentLogic.GetStudentById(id);
            return Ok(result);
        }

        [HttpPost("new-student")]
        public IActionResult NewStudent([FromBody] Student student)
        {
            _studentLogic.InsertStudents(student);
            return Ok();
        }
    }
}
