using ASPNETWebAPI_Token.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWebAPI_Token.Controllers
{
    public class StudentsV2Controller : ApiController
    {
        static List<Student2> students = new List<Student2>()
         {
             new Student2() { ID = 1, FirstName = "Tom", LastName = "T"},
             new Student2() { ID = 2, FirstName = "Sam", LastName = "S"},
             new Student2() { ID = 3, FirstName = "John", LastName = "J"}
         };

        [Route("api/v2/students")]
        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        [Route("api/v2/students/{id}")]
        public IHttpActionResult Get(int id)
        {
            Student2 student = students.FirstOrDefault(s => s.ID == id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, "Student not found.");
            return Ok(student);
        }
    }
}