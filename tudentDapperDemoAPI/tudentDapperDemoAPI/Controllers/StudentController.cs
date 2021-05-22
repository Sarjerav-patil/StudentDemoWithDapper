using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDapperDemoAPI.DAL;
using StudentDapperDemoAPI.Models;

namespace StudentDapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentRespository _ourStudentRespository;
        public StudentController()
        {
            _ourStudentRespository = new StudentRespository(new StudentDbContext());
        }

        // GET: /Customer
        [Route("Students")]
        [HttpGet]
        public List<Student> Get()
        {
            return _ourStudentRespository.GetStudents(10, "ASC");
        }

        [Route("Students")]
        [HttpPost]
        public void Post([FromBody]Student ourStudent)
        {
            _ourStudentRespository.InsertStudent(ourStudent);
        }

        [Route("Students/{StudId}")]
        [HttpGet]
        public Student GetSingleStudent(int StudId)
        {
            return _ourStudentRespository.GetSingleStudent(StudId);
        }

        [Route("Students/{StudId}")]
        [HttpDelete]
        public void Delete(int StudId)
        {
           _ourStudentRespository.DeleteStudent(StudId);
        }
        [Route("Students")]
        [HttpPut]
        public void Put([FromBody]Student ourStudent)
        {
            _ourStudentRespository.UpdateStudent(ourStudent);
        }
    }
}