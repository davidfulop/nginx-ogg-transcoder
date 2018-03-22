using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace NOTranscoder.TestServer.Controllers
{
    [Route("[controller]")]
    public class MediaController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id == 314159265) return StatusCode(418);
            // The test server returns the same track regardless of the id
            var fs = new FileStream("assets/test01.flac", FileMode.Open);
            return new FileStreamResult(fs, "audio/flac");
        }
    }
}
