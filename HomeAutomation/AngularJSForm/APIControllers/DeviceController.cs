using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeAutomation.APIControllers
{
    public class DeviceController : ApiController
    {
        private HomeAutomationApiClient client = new HomeAutomationApiClient();

        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]string userId, [FromUri]string device)
        {
            var devices = client.GetDevices(userId, device);

            return Ok<List<Device>>(devices);
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]string userId, [FromUri] string device, [FromBody]Data data)
        {
            client.UpdateDevice(userId, device, data);

            return Ok();
        }
    }
}
