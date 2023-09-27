using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetAction()
        {
            var svc = new WeatherForecastService();
            return new OkObjectResult(await svc.GetForecastAsync(System.DateTime.Now));
        }
    }
}