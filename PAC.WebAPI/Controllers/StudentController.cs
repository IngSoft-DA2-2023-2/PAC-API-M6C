using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.DataAccess;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.IDataAccess;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller/Users]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [HttpGet]
        public ActionResult<Student> getStudentById(int id)
        {
            StudentsRepository<Student> db = new StudentsRepository<Student>(new PacContext());
            if (id != null)
            {
                Student student = db.GetStudentById(id);
                if (student != null)
                {
                    return student;
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<List<Student>> getStudents()
        {
            StudentsRepository<Student> db = new StudentsRepository<Student>(new PacContext());
            return db.GetStudents().ToList();
        }

        [HttpPost]
        public ActionResult<Student> postStudent(int id, string name)
        {
            StudentsRepository<Student> db = new StudentsRepository<Student>(new PacContext());
            if (id != null && name != null)
            {
                Student student = new Student();
                student.Name = name;
                student.Id = id;
                db.InsertStudents(student);

                return Ok();
            }

            return BadRequest();
        }
    }
}
