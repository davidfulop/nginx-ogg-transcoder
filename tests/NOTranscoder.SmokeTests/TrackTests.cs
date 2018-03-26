using System.IO;
using System.Net;
using NUnit.Framework;

namespace NOTranscoder.SmokeTests
{
    public class TrackTests
    {
        const string NGINX_URL = "http://nginx/media/";
        const string VALID_TRACK_ID = "0";

        [Test]
        public void Track_returns_media_for_valid_request()
        {
            var request = WebRequest.Create(NGINX_URL + VALID_TRACK_ID);
            var response = request.GetResponse() as HttpWebResponse;
            var responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            var x = sr.ReadToEnd();            
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(responseStream);
            Assert.IsTrue(x.Length > 1024 * 1024);
        }
    }
}
