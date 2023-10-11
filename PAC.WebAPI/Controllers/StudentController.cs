﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Models;

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
        public IActionResult GetStudents()
        {
            var users = _studentLogic.GetStudents();
            return Ok(users);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetStudentsById(int id)
        {
            var users = _studentLogic.GetStudentById(id);
            return Ok(users);
        }
        
        [HttpPost]
        public IActionResult InsertStudent([FromBody] StudentCreateModel newStudent)
        {
            _studentLogic.InsertStudents(newStudent.ToEntity());
            return Ok();
        }
    }
}
