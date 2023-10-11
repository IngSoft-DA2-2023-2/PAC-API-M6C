using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.DataAccess;
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
        public ObjectResult GetStudents()
        {
            IEnumerable<Student> students= _studentLogic.GetStudents();

            return Ok(students);
        }
        public ObjectResult GetStudentById(int v)
        {
            throw new NotImplementedException();
        }
    }
}
