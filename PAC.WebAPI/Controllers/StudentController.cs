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

        [HttpPost]
        public void AddStudent(Student aStudent)
        {
            _studentLogic.InsertStudents(aStudent);
        }

        [HttpGet]
        public object GetAllStudents()
        {
            return _studentLogic.GetStudents();
        }

        [HttpGet("{id}")]
        public object GetStudentById(int id)
        {
            return _studentLogic.GetStudentById(id);
        }
    }
}
