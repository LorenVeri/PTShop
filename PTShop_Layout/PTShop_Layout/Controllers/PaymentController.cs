using Microsoft.AspNetCore.Mvc;

namespace PTShop_Layout.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
