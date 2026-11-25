using Assinment_MVC1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assinment_MVC1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductStore _store = new();

        public IActionResult Index()
        {
            return View(_store.GetAll());
        }

        // GET /Products/Details/2
        // View(model) → ViewResult. NotFound() → 404.
        // sort هنا من ترتيب البحث الافتراضي، من غير [FromQuery].
        public IActionResult Details(int id, string? sort)
        {
            var product = _store.GetById(id);
            if (product is null)
                return NotFound();     // 404

            ViewData["Sort"] = sort;
            return View(product);      // 200 + HTML
        }

        [NonAction]                    // NOT reachable by URL
        public void Helper() { }

        // JsonResult بس. النوع هنا JsonResult مش IActionResult.
        public JsonResult GetProduct()
            => Json(new { Id = 1, Name = "Laptop" });

        // IActionResult: النتيجة بتتغير حسب الشرط.
        // NotFound = 404، RedirectToAction = 302 لأكشن تاني، Json = JSON.
        public IActionResult Product(int id)
        {
            if (id > 100) return NotFound();
            if (id == 42) return RedirectToAction("Index");
            return Json(new { Id = id });
        }
    }

    public class ProductStore
    {
        private readonly List<Product> _products =
        [
            new Product { Id = 1, Name = "Laptop" }
        ];

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public IReadOnlyList<Product> GetAll() => _products;
    }
}
