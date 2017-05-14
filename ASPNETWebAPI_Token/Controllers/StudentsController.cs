using ASPNETWebAPI_Token.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWebAPI_Token.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { ID = 1, Name = "Tom" },
            new Student() { ID = 2, Name = "Sam" },
            new Student() { ID = 3, Name = "John" }
        };

        public IEnumerable<Student> Get()
        {
            return students;
        }

        [Route("{id:int}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.ID == id);
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
    }
}