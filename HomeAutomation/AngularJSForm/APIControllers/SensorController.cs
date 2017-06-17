using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeAutomation.APIControllers
{
    [RoutePrefix("sensor")]
    public class SensorController : ApiController
    {
        private HomeAutomationApiClient client = new HomeAutomationApiClient();

        // GET api/<controller>
        [HttpGet]
        [Route("{userId}/{device}")]
        public IEnumerable<Device> Get([FromUri]string userId, [FromUri]string device)
        {
            var devices = client.GetDevices(userId, device);

            return devices;
        }

        [HttpPut]
        // PUT api/<controller>/5
        [Route("{userId}/{device}")]
        public void Put([FromUri]string userId, [FromUri] string device, [FromBody]Data data)
        {
            client.UpdateDevice(userId, device, data);
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}