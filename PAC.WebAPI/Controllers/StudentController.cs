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

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentLogic.GetStudents();
            return Ok(students);
        }
    }
}

