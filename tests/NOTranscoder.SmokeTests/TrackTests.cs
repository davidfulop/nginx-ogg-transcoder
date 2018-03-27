using System.IO;
using System.Net;
using NUnit.Framework;

namespace NOTranscoder.SmokeTests
{
    public class TrackTests
    {
        const string NGINX_URL = "http://nginx/media/";
        const string VALID_TRACK_ID = "0";
        const int SIZE_1M = 1024 * 1024;

        [Test]
        public void Track_returns_200OK_for_valid_request()
        {
            var request = WebRequest.Create(NGINX_URL + VALID_TRACK_ID);
            var response = request.GetResponse() as HttpWebResponse;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Unexpected {response.StatusCode} status.");
        }

        [Test]
        public void Track_returns_media_for_valid_request()
        {
            var request = WebRequest.Create(NGINX_URL + VALID_TRACK_ID);
            var response = request.GetResponse() as HttpWebResponse;
            var responseStream = response.GetResponseStream();
            
            Assert.IsNotNull(responseStream, "Response stream was null.");

            using (var sr = new StreamReader(responseStream))
            {
                var responseString = sr.ReadToEnd();

                Assert.IsTrue(responseString.Length > SIZE_1M, $"Response stream was {responseString.Length} bytes long.");
            }
        }

        [Test]
        public void Track_returns_audio_ogg_as_content_type()
        {
            var request = WebRequest.Create(NGINX_URL + VALID_TRACK_ID);
            var response = request.GetResponse() as HttpWebResponse;

            Assert.IsNotNull(response.Headers["Content-Type"], "Content-Type header missing.");
            Assert.IsTrue(response.Headers["Content-Type"] == "audio/ogg", $"Unexpected Content-Type header: {response.Headers["Content-Type"]}");
        }
    }
}
