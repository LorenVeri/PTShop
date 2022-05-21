using Microsoft.AspNetCore.Mvc;

namespace PTShop_Layout.Controllers
{
    [Route("chi-tiet/[controller]")]
    [ApiController]
    public class ProductDetailController : Controller
    {
        
        [HttpGet("chi-tiet/{id:int}")] // GET /api/test2/int/3
        public IActionResult Index(int id)
        {
            return View(id);
        }

        
    }
}
