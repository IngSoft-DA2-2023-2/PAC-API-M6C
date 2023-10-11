using Microsoft.AspNetCore.Mvc;
using PAC.BusinessLogic;
using PAC.Domain;
using PAC.IBusinessLogic;
using System.Collections.Generic;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentLogic.GetStudentById(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentLogic.GetStudents();
            return Ok(students);
        }
    }
}

