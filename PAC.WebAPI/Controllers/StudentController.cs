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
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post(Student student)
        {
            try
            {
                _studentLogic.InsertStudents(student);
                return Ok("Student created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create student: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentLogic.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve students: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _studentLogic.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound("Student not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve student: " + ex.Message);
            }
        }
    }
}


