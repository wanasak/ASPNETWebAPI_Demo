using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public IEnumerable<tblEmployee> LoadEmployees()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.tblEmployees.ToList();
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var emp = entities.tblEmployees.FirstOrDefault(e => e.ID == id);
                if (emp != null)
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " not found");
            }
        }

        public HttpResponseMessage Post([FromBody]tblEmployee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.tblEmployees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var emp = entities.tblEmployees.FirstOrDefault(e => e.ID == id);
                    if (emp != null)
                    {
                        entities.tblEmployees.Remove(emp);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id {id.ToString()} not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]tblEmployee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var emp = entities.tblEmployees.FirstOrDefault(e => e.ID == id);
                    if (emp != null)
                    {
                        emp.First = employee.First;
                        emp.Last = employee.Last;
                        emp.Gender = employee.Gender;
                        emp.Salary = employee.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, emp);
                    }
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with id { id.ToString() } not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}