using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*it uses MVC
    there is not default */

namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/Calculator/Add?x=10&y=1
        [HttpGet("/CalculatorAdd")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        //api/Calculator/Add?x=10&y=1
        [HttpGet("/CalculatorSum")]
        public int Sum(int x, int y)
        {
            return x + y+1000;
        }
        [HttpPost]
        public int Subtract(int x, int y)
        {
            return x - y;
        }

        //api/Calculator/Multiply?x=10&y=1
        [HttpPut]

        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/Calculator/Divide?x=10&y=1
        [HttpDelete]

        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
