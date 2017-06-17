using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeAutomation.APIControllers
{
    public class HomeUserController : ApiController
    {
        private HomeAutomationApiClient client = new HomeAutomationApiClient();
        public IEnumerable<Device> GetDevice([FromUri]string userId, [FromUri]string device)
        {
            var devices = client.GetDevices(userId, device);

            return devices;
        }

        [HttpPut]
        // PUT api/<controller>/5
        [Route("{userId}/{device}")]
        public void UpdateDevicet([FromUri]string userId, [FromUri] string device, [FromBody]Data data)
        {
            client.UpdateDevice(userId, device, data);

        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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