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
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(401)]
        [HttpGet("{Id}", Name = "GetStudent")]
        public IActionResult Get()
        {
            var students = this._studentLogic.GetStudents();
            if (students.Count() > 0)
            {
                return Ok(students);
            }
            return NotFound("No hay estudiantes en el sistema.");
        }
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(401)]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var student = this._studentLogic.GetStudentById(id);
            if (student == null)
            {
                return NotFound("No existe el estudiante con Id: " + id);
            }
            return Ok(student);
        }
        [ProducesResponseType(typeof(Student), 201)]
        [ProducesResponseType(401)]
        [HttpPost()]
        public IActionResult Post([FromBody] Student oneStudent)
        {

            this._studentLogic.InsertStudents(oneStudent);
            return CreatedAtRoute("GetStudent", new { id = oneStudent.Id }, oneStudent);
        }
    }
}
