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
        //[AuthorizationFilter]
        //[ActionFilter("admin")]
        public IActionResult Get(int id)
        {
            var student = _studentLogic.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            var student = new Student() { Name = name };
            _studentLogic.InsertStudents(student);
            return Ok(student);
        }
    }
}
