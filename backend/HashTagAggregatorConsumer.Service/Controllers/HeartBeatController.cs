using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HashTagAggregatorConsumer.Service.Controllers
{
    [Route("api/[controller]")]
    public class HeartBeatController : Controller
    {
        [HttpGet("start/{hashtag:required}")]
        public Task<IActionResult> Start(string hashtag)
        {
            throw new NotImplementedException();
        }

        [HttpGet("stop/{hashtag:required}")]
        public IActionResult Stop(string hashtag)
        {
            throw new NotImplementedException();
        }
    }
}