using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("/DemoAdd")]
        public int Add(int x, int y)
        {
            return x + y+50000;
        }
    }
}
