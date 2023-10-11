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
        public IActionResult GetAllStudents()
        {
            try
            {
                return Ok(_studentLogic.GetStudents());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentLogic.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }
        [HttpPost]
        
        public ActionResult CreateStudent([FromBody] Student student)
        {


            var userRole = HttpContext.Request.Headers["UserRole"].ToString();
            if (string.IsNullOrEmpty(userRole) || userRole != "admin")
            {
                return Forbid();
            }

            if (student == null)
            {
                return BadRequest("Student is null");
            }

            _studentLogic.InsertStudents(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }   

    }
}
