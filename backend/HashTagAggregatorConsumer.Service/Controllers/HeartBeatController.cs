using Microsoft.AspNetCore.Mvc;
using HashtagAggregatorConsumer.Contracts.Interface;

namespace HashTagAggregatorConsumer.Service.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class HeartBeatController : Controller
    {
        private readonly IBackgroundServiceWorker worker;

        public HeartBeatController(IBackgroundServiceWorker worker)
        {
            this.worker = worker;
        }

        [HttpGet("start/{name:required}/{interval:int}")]
        public IActionResult Start(string name, int interval)
        {
            var result = worker.Start(name, interval);
            return Ok(result);
        }

        [HttpGet("stop/{name}")]
        public IActionResult Stop(string name)
        {
            var result = worker.Stop(name);
            return Ok(result);
        }
    }
}