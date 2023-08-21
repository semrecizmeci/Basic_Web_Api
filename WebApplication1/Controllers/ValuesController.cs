using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcApideneme.Models;

namespace mvcApideneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("postdata")]
        public IActionResult PostData([FromBody] DataModel model)
        {
            // Alınan model verisi ile yapılacak işlemleri gerçekleştirin
            // Örneğin: Veritabanına kaydetme işlemi
            if (model.name==null)
            {
                return Ok("api den geliyorum, null geldi");
            }
            return Ok("galiba tamamım");

        }

        //private IActionResult Ok(string name, string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
