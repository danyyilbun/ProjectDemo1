using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerEntityLibrary;
using Utils;

namespace ProjectDemo1.Controllers
{
    public class CustomerController : ApiController
    {

        Demo1Entities myDb = new Demo1Entities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var myDbCustomer = myDb.Customers.Find(id);

            if (myDbCustomer == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }

            var myApiCustomer = new ApiCustomer();

            PropertyCopier<Customer, ApiCustomer>.Copy(myDbCustomer, myApiCustomer);

            return Request.CreateResponse(HttpStatusCode.OK, myApiCustomer);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}