using Microsoft.AspNetCore.Mvc;

namespace Assinment_MVC1.Controllers
{
    // قيود الـ Routing.
    // القيد لو فشل: مفيش match، والنتيجة 404.
    // منفصلة عن مسار shop/{id:int} بتاع المنتجات.
    [Route("constraints")]
    public class ConstraintsController : Controller
    {
        // {id:int} → أرقام صحيحة
        [HttpGet("int/{id:int}")]
        public IActionResult IntConstraint(int id)
            => Content($"id = {id}");

        // {id:min(1)} → أكبر من أو يساوي 1
        [HttpGet("min/{id:min(1)}")]
        public IActionResult MinConstraint(int id)
            => Content($"id = {id}");

        // {name:alpha} → حروف بس
        [HttpGet("alpha/{name:alpha}")]
        public IActionResult AlphaConstraint(string name)
            => Content($"name = {name}");

        // {name:length(3,20)} → من 3 لـ 20 حرف
        [HttpGet("length/{name:length(3,20)}")]
        public IActionResult LengthConstraint(string name)
            => Content($"name = {name}");

        // {date:datetime} → تاريخ
        [HttpGet("date/{date:datetime}")]
        public IActionResult DateConstraint(DateTime date)
            => Content($"date = {date:yyyy-MM-dd}");
    }
}
