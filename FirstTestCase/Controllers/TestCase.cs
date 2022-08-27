using Microsoft.AspNetCore.Mvc;
using System.IO;
using FirstTestCase.ActionFilters;

namespace FirstTestCase.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestCase : ControllerBase{

    
        [LogActionFilter]
        [Route("GetResult")]
        [HttpGet]
        public string Get()
        {
            return System.IO.File.ReadAllText("TextFile1.txt"); ;
        }

        [LogActionFilter]
        [Route("DeleteResult")]
        [HttpDelete]
        public string Delete()
        {
            string path = "TextFile1.txt";
            System.IO.File.WriteAllBytes(path, new byte[0]);
            return "Filewasbecleaned";
        }

        [LogActionFilter]
        [HttpPost]
        [Route("PostResult")]
        public string Post()
        {
            System.IO.File.AppendAllText("TextFile1.txt", "FIleWasRewrite");
            return "FIleWasRewrite";
        }

    }
}