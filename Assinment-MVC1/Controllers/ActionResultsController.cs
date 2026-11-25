using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Assinment_MVC1.Controllers
{
    // جدول Action Results.
    // الأكشنز دي منفصلة عن ProductsController عشان متتلخبطش مع مثال المنتجات.
    [Route("action-results")]
    public class ActionResultsController : Controller
    {
        // PartialView() → PartialViewResult → جزء من الصفحة من غير layout
        [HttpGet("partial")]
        public IActionResult PartialDemo()
            => PartialView();

        // Content("text") → ContentResult → plain text
        [HttpGet("content")]
        public IActionResult ContentDemo()
            => Content("text");

        // Redirect(url) → RedirectResult → 302 لأي URL
        [HttpGet("redirect")]
        public IActionResult RedirectDemo()
            => Redirect("/Products");

        // BadRequest() → 400
        [HttpGet("bad-request")]
        public IActionResult BadRequestDemo()
            => BadRequest();

        // Ok() → 200
        [HttpGet("ok")]
        public IActionResult OkDemo()
            => Ok();

        // File(bytes, type, name) → FileResult → تحميل ملف
        [HttpGet("file")]
        public IActionResult FileDemo()
        {
            byte[] bytes = Encoding.UTF8.GetBytes("file download");
            return File(bytes, "text/plain", "demo.txt");
        }
    }
}
