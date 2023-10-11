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
        public IActionResult Get()
        {
            return Ok(_studentLogic.GetStudents());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_studentLogic.GetStudentById(id));
        }

        [HttpPost]
        [AuthenticationFilter]
        public IActionResult Post(Student student , [FromHeader] string authorizationHeader) 
        {
            try
            {
                _studentLogic.InsertStudents(student);
                return Ok("Estudiante creado");
            }catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
