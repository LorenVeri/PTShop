using Microsoft.AspNetCore.Mvc;

namespace PTShop_Layout.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
