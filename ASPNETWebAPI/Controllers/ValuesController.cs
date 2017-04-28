using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> fruits = new List<string>()
        {
            "Banana", "Apple", "Orange"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return fruits;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return fruits[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            fruits.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            fruits[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            fruits.RemoveAt(id);
        }
    }
}
