using System.Collections.Generic;
using System.Xml.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace HelloApp
{
    public class CameraService
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<Camera>> Get()
        {

            HttpResponseMessage response = await client.GetAsync("http://demo.macroscop.com/configex?login=root");

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            XDocument xDoc = XDocument.Parse(responseBody);

            var cameras = from c in xDoc.Root.Descendants("ChannelInfo")
                          select new Camera()
                          {
                              Id = c.Attribute("Id").Value,
                              Name = c.Attribute("Name").Value,
                              IsSoundOn = bool.Parse(c.Attribute("IsSoundOn").Value),
                              AttachedToServer = c.Attribute("AttachedToServer").Value
                          };

            return cameras;
        }
    }
}
