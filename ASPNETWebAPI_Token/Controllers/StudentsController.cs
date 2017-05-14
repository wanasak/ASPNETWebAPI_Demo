using ASPNETWebAPI_Token.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

// Advantages of IHttpActionResult
// 1) The code is cleaner and easier to read
// 2) Unit teting controller action method is much simpler.
// Helper methods of IHttpActionResult
// Ok(), NotFound(), BadRequest(), Conflict(), Created(), InternalServerError(), Redirect() and Unauthorization()

namespace ASPNETWebAPI_Token.Controllers
{
    //[RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { ID = 1, Name = "Tom" },
            new Student() { ID = 2, Name = "Sam" },
            new Student() { ID = 3, Name = "John" }
        };

        // Using HttpResponseMessage
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse(students);
        //}
        [Route("api/v1/students")]
        // Using IHttpActionResult
        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        [Route("api/v1/students/{id:int}", Name = "GetStudentByID")]
        //public HttpResponseMessage Get(int id)
        //{
        //    Student student = students.FirstOrDefault(s => s.ID == id);
        //    if (student == null)
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found.");
        //    return Request.CreateResponse(student);
        //}
        public IHttpActionResult Get(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, "Student not found.");
            return Ok(student);
        }

        [Route("{name}")]
        public Student Get(string name)
        {
            return students.FirstOrDefault(s => s.Name.ToUpper() == name.ToUpper());
        }

        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }

        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri + "/" + student.ID.ToString());
            response.Headers.Location = new Uri(Url.Link("GetStudentByID", new { id = student.ID }));
            return response;
        }
    }
}