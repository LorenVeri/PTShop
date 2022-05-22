using Microsoft.AspNetCore.Mvc;

namespace PTShop_Layout.Controllers
{
    public class ProductDetailController : Controller
    {
        //[HttpGet("{id}", Name = "ProductDetail")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
