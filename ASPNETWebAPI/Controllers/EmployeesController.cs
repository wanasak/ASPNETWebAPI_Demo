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
        public IEnumerable<tblEmployee> Get()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.tblEmployees.ToList();
            }
        }

        public tblEmployee Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.tblEmployees.FirstOrDefault(e => e.ID == id);
            }
        }
    }
}