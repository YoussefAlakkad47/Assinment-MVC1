using Assinment_MVC1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assinment_MVC1.Controllers
{
    // مصادر الـ Model Binding.
    // كل أكشن هنا بيجبر مصدر واحد بالـ attribute.
    // ده غير Details في ProductsController، اللي بيستخدم ترتيب البحث الافتراضي: Form ثم Route ثم Query.
    [Route("binding")]
    public class BindingController : Controller
    {
        // [FromRoute] → قيمة من مسار الـ URL
        [HttpGet("route/{id:int}")]
        public IActionResult FromRouteDemo([FromRoute] int id)
            => Content($"id = {id}");

        // [FromQuery] → بعد علامة ؟ في الـ URL
        [HttpGet("query")]
        public IActionResult FromQueryDemo([FromQuery] string sort)
            => Content($"sort = {sort}");

        // [FromForm] → حقول فورم متبعتة بـ POST. الصفحة دي بس بتعرض الفورم.
        [HttpGet("form")]
        public IActionResult FormPage()
            => View();

        // [FromForm] → القراءة من الفورم، مش من الـ query
        [HttpPost("form")]
        public IActionResult FromFormDemo([FromForm] string name)
            => Content($"name = {name}");

        // [FromHeader] → هيدر من الـ request
        [HttpGet("header")]
        public IActionResult FromHeaderDemo([FromHeader(Name = "X-Demo")] string? value)
            => Content($"header = {value}");

        // [FromBody] → جسم الطلب JSON
        [HttpPost("body")]
        public IActionResult FromBodyDemo([FromBody] Product product)
            => Content($"id = {product.Id}, name = {product.Name}");

        // [FromServices] → من الـ DI، مش من الطلب
        [HttpGet("services")]
        public IActionResult FromServicesDemo([FromServices] IWebHostEnvironment env)
            => Content(env.EnvironmentName);

        // Complex type: الـ binder بيعمل الأوبجكت ويملى كل property بالاسم.
        // age=abc → Age بتاخد 0، ويتسجل خطأ في ModelState.
        [HttpGet("complex")]
        public IActionResult Complex(AgeExample input)
        {
            string state = ModelState.IsValid ? "ModelState valid" : "ModelState error";
            return Content($"age = {input.Age}; {state}");
        }

        // Collections: نفس الاسم يتكرر فيربط ليست
        // /binding/collection?ids=1&ids=2
        [HttpGet("collection")]
        public IActionResult Collection(List<int> ids)
            => Content(string.Join(", ", ids));
    }

    // مش Product. مثال الـ complex type بتاع age بس.
    public class AgeExample
    {
        public int Age { get; set; }
    }
}
