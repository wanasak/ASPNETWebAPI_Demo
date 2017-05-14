using EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWebAPI_Token.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDB_WebAPITokenBaseAuthenEntities entities = new EmployeeDB_WebAPITokenBaseAuthenEntities())
            {
                return entities.Employees.ToList();
            }
        }
    }
}