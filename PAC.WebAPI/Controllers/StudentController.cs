using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;
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
        public IActionResult GetAll()
        {
            var students = _studentLogic.GetStudents();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentLogic.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        //[AuthorizationFilter]
        public IActionResult Create(string name, int id)
        {
            var student = new Student() { Name = name, Id = id };
            _studentLogic.InsertStudents(student);
            return Ok(student);
        }
    }
}
