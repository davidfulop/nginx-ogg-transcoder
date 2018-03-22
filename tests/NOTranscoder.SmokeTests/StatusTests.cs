using System.Net;
using NUnit.Framework;

namespace NOTranscoder.SmokeTests
{
    public class StatusTests
    {
        string STATUS_URL = "http://nginx/status";

        [Test]
        public void Status_returns_200OK()
        {
            WebRequest request = WebRequest.Create(STATUS_URL);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
