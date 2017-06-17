using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace Common
{
    public class HomeAutomationApiClient
    {
        private HttpClient client = new HttpClient();

        private string url;

        public HomeAutomationApiClient()
        {
            url = ConfigurationManager.AppSettings.Get("Url");
        }

        public List<Device> GetDevices(string userId,string device)
        {
            List<Device> devices = null;

            try
            {
                string data = client.GetStringAsync(string.Format("{0}/{1}/{2}", url,userId,device)).Result;
                devices = JsonConvert.DeserializeObject<List<Device>>(data);
            }
            catch (Exception)
            {
                throw;
            }
                            
            return devices;
        }

        public void UpdateDevice(string userId, string sensor, Data data)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var result = client.PutAsync(url, content).Result;

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
