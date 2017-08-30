using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Skeleton.Controllers{

    [Route("error")]
    public class Error : Controller{

        private readonly ILogger<Error> mLog;

        public Error(ILogger<Error> log){
            mLog = log;
        }

        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        [Route("sample")]
        public IActionResult Sample(){
            return View();
        }
    }
}