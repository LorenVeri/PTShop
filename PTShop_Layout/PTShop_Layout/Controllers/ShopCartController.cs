using Microsoft.AspNetCore.Mvc;

namespace PTShop_Layout.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
