using Microsoft.AspNetCore.Mvc;

namespace Assinment_MVC1.Controllers
{
    // Attribute routing. الأكشنز دي بتتجاهل المسارات العادية زي shop والـ default.
    [Route("results")]
    public class ResultsController : Controller
    {
        [HttpGet("json")]              // GET /results/json
        public IActionResult Json()
            => new JsonResult(new { Id = 1, Name = "Laptop" });

        // StatusCode(code) → أي status code. القيد {code:int}.
        [HttpGet("status/{code:int}")]
        public IActionResult Status(int code)
            => StatusCode(code);
    }
}
